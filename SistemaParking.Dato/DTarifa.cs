using SistemaParking.Datos;
using SistemaParking.Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParking.Dato
{
    public class DTarifa : ConnectionSql
    {
        public ETarifa ObtenerTarifa(int idTarifa)
        {
            try
            {
                using (var cn = GetConnection())
                using (var command = new SqlCommand(@"SELECT id_tarifa, descripcion, monto_por_hora, fraccion_minutos, monto_fraccion, estado, Codigo FROM Tarifa 
                    WHERE id_tarifa = @IdTarifa AND estado = 1", cn)) //esta consulta trae los datos del catálogo de tarifas, filtrando por ID y estado activo
                {
                    command.Parameters.AddWithValue("@IdTarifa", idTarifa); //se asignas parametros
                    cn.Open();//abrimos conexion

                    using (var reader = command.ExecuteReader()) //ejecuta la consulta
                    {
                        if (!reader.Read()) return null; //Verificas si hay resultados si no hay se devuelve null


                        return new ETarifa //sí hay fila, se construye un objeto ETarifa con los valores de las columnas
                        {
                            id_tarifa = reader.GetInt32(0),
                            descripcion = reader.GetString(1),
                            monto_por_hora = reader.GetDecimal(2),
                            fraccion_minutos = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3),
                            monto_fraccion = reader.IsDBNull(4) ? (decimal?)null : reader.GetDecimal(4),
                            Estado = reader.GetBoolean(5),
                            Codigo = reader.GetString(6)
                        };
                    }
                }
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public bool RegistrarTarifa( string descripcion, decimal montoHora, int fraccionMinuto, decimal montoFraccion, string nombreTipoVehiculo)
        {
            try
            {
                using (var cn = GetConnection())
                {
                    cn.Open();

                    // 1. Obtener código del tipo de vehículo
                    string codigoTipoVehiculo;
                    using (var cmdSelect = new SqlCommand("SELECT Codigo FROM TiposVehiculo WHERE Descripcion = @Descripcion", cn))
                    {
                        cmdSelect.Parameters.AddWithValue("@Descripcion", nombreTipoVehiculo);
                        codigoTipoVehiculo = cmdSelect.ExecuteScalar()?.ToString();
                    }

                    if (string.IsNullOrEmpty(codigoTipoVehiculo))
                        return false;

                    // 2 Insertar tarifa
                   
                    using(var cmdInsertarTarifa = new SqlCommand(@"INSERT INTO Tarifa (descripcion, monto_por_hora, fraccion_minutos,monto_fraccion, Codigo)
                        Values (@Descripcion, @Monto_por_hora,@Fraccion_minutos, @Monto_fraccion, @Codigo  )", cn))
                    {
                        cmdInsertarTarifa.Parameters.AddWithValue("@Descripcion", descripcion);
                        cmdInsertarTarifa.Parameters.AddWithValue("@Monto_por_hora",montoHora);
                        cmdInsertarTarifa.Parameters.AddWithValue("@Fraccion_minutos",fraccionMinuto);
                        cmdInsertarTarifa.Parameters.AddWithValue("@Monto_fraccion",montoFraccion);
                        cmdInsertarTarifa.Parameters.AddWithValue("@Codigo",codigoTipoVehiculo);

                        return cmdInsertarTarifa.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
    }
}
