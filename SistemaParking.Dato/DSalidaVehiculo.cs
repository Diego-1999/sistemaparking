using SistemaParking.Datos;
using SistemaParking.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParking.Dato
{
    public class DSalidaVehiculo : ConnectionSql
    {
        public (int idEntrada, DateTime fechaEntrada, ETarifa tarifa) ObtenerInfoSalida(string placa)
        {
            try
            {
                using (var cn = GetConnection())
                {
                    cn.Open();

                    using (var command = new SqlCommand(@"SELECT TOP 1
                                                                e.id_entrada,
                                                                e.fecha_hora_entrada,
                                                                t.id_tarifa,
                                                                t.monto_por_hora,
                                                                t.fraccion_minutos,
                                                                t.monto_fraccion
                                                        FROM Entrada e INNER JOIN Vehiculo v ON v.id_vehiculo = e.id_vehiculo
                                                        INNER JOIN Tarifa t ON t.Codigo = v.Codigo AND t.estado = 1
                                                        LEFT JOIN Salida s ON s.id_entrada = e.id_entrada
                                                        WHERE v.placa = @Placa AND s.id_salida IS NULL
                                                        ORDER BY e.fecha_hora_entrada DESC", cn))
                    {
                        command.Parameters.AddWithValue("@Placa", placa);

                        using (var r = command.ExecuteReader())
                        {
                            if (!r.Read())
                                throw new Exception("No existe entrada activa o tarifa asociada.");

                            return (
                                r.GetInt32(0),
                                r.GetDateTime(1),
                                new ETarifa
                                {
                                    id_tarifa = r.GetInt32(2),
                                    monto_por_hora = r.GetDecimal(3),
                                    fraccion_minutos = r.IsDBNull(4) ? (int?)null : r.GetInt32(4),
                                    monto_fraccion = r.IsDBNull(5) ? (decimal?)null : r.GetDecimal(5)

                                }
                            );
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
            
        }


        public void RegistrarSalida(string placa, string numeroIdColaborador, decimal total)
        {
            try
            {
                using (var cn = GetConnection())
                {
                    cn.Open();
                    using (var tx = cn.BeginTransaction())
                    {
                        try
                        {
                            int idEntrada;
                            string codigoTipoVehiculo;

                            // 1. Entrada activa
                            using (var command = new SqlCommand(@" SELECT TOP 1 
                                                                        e.id_entrada, 
                                                                        v.Codigo 
                                                                FROM Entrada e INNER JOIN Vehiculo v ON v.id_vehiculo = e.id_vehiculo 
                                                                LEFT JOIN Salida s ON s.id_entrada = e.id_entrada WHERE v.placa = @Placa AND s.id_salida IS NULL
                                                                ORDER BY e.fecha_hora_entrada DESC", cn, tx))
                            {
                                command.Parameters.AddWithValue("@Placa", placa); //Se asignan parametros
                                using (var result = command.ExecuteReader()) //Se ejecuta la consulta 
                                {
                                    if (!result.Read())
                                        throw new Exception("No existe entrada activa");

                                    idEntrada = result.GetInt32(0);
                                    codigoTipoVehiculo = result.GetString(1);
                                }
                            }

                            // 2. Obtener tarifa SOLO para el ID
                            int idTarifa;
                            using (var command = new SqlCommand(@"SELECT TOP 1 id_tarifa FROM Tarifa
                                WHERE Codigo = @Codigo AND estado = 1", cn, tx))
                            {
                                command.Parameters.AddWithValue("@Codigo", codigoTipoVehiculo);
                                idTarifa = (int)command.ExecuteScalar();
                            }

                            // 3. Registrar salida (CON TOTAL)
                            using (var command = new SqlCommand(@"INSERT INTO Salida (fecha_hora_salida, total_pagar, id_entrada, id_tarifa, numero_id)
                                VALUES (GETDATE(), @Total, @IdEntrada, @IdTarifa, @NumeroId)", cn, tx))
                            {
                                command.Parameters.AddWithValue("@Total", total);
                                command.Parameters.AddWithValue("@IdEntrada", idEntrada);
                                command.Parameters.AddWithValue("@IdTarifa", idTarifa);
                                command.Parameters.AddWithValue("@NumeroId", numeroIdColaborador);
                                command.ExecuteNonQuery();
                            }

                            tx.Commit();
                        }
                        catch
                        {
                            tx.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
