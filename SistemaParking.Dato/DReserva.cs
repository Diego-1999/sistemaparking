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
    public class DReserva : ConnectionSql
    {
        public List<EReserva> GetReserva()
        {
			try
			{
				var lista = new List<EReserva>();

				using (var cn = GetConnection())
				{
					cn.Open();

					using (var command = new SqlCommand("Select * From Reserva", cn))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								var reserva = new EReserva
								{
									id_reserva = reader.GetInt32(0),
									descripcion_reserva = reader.GetString(1)
								};
								lista.Add(reserva);

							}
						}
					}
				}
				return lista;
			}
			catch (Exception)
			{

				throw;
			}
        }



		//metodo guardar tarifa reserva
		public bool RegistrarTarifaReserva(string descripcion, int monto,  string diaReserva, string tipoVehiculo)
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
                        cmdSelect.Parameters.AddWithValue("@Descripcion", tipoVehiculo);
                        codigoTipoVehiculo = cmdSelect.ExecuteScalar()?.ToString();
                    }

                    if (string.IsNullOrEmpty(codigoTipoVehiculo))
                        return false;

					// 2. Obtener el id_Reserva de Reseerva
					int id_Reserva;
					using (var cmdSelect = new SqlCommand("SELECT id_reserva FROM Reserva WHERE descripcion_reserva = @descripcion_reserva", cn))
					{
						cmdSelect.Parameters.AddWithValue("descripcion_reserva", diaReserva);
                        object result = cmdSelect.ExecuteScalar();

                        if (result != null)
                        {
                            id_Reserva = Convert.ToInt32(result);
                        }
                        else
                        {
                            // No se encontró la reserva
                            id_Reserva = -1;
                        }
                    }

                    // 2 Insertar tarifa

                    using (var cmdInsertarTarifa = new SqlCommand(@"INSERT INTO Tarifa (descripcion, monto_por_hora, Codigo, id_reserva)
                        Values (@Descripcion, @Monto_por_hora,@Codigo, @id_reserva)", cn))
                    {
                        cmdInsertarTarifa.Parameters.AddWithValue("@Descripcion", descripcion);
                        cmdInsertarTarifa.Parameters.AddWithValue("@Monto_por_hora", monto);
                        cmdInsertarTarifa.Parameters.AddWithValue("@id_reserva", id_Reserva);
                        cmdInsertarTarifa.Parameters.AddWithValue("@Codigo", codigoTipoVehiculo);

                        return cmdInsertarTarifa.ExecuteNonQuery() > 0;
                    }

                }
			}
			catch (Exception)
			{
				throw;
			}
		}

        public ETarifa ObtenerTarifaReserva(int idTarifa)
        {
            try
            {
                using (var cn = GetConnection())
                {
                    cn.Open();

                    using (var command = new SqlCommand(@"
                SELECT id_tarifa, descripcion, monto_por_hora, Codigo, id_reserva 
                FROM Tarifa 
                WHERE id_tarifa = @IdTarifa AND estado = 1", cn))
                    {
                        command.Parameters.AddWithValue("@IdTarifa", idTarifa);

                        using (var reader = command.ExecuteReader())
                        {
                            if (!reader.Read())
                                return null;

                            return new ETarifa
                            {
                                id_tarifa = reader.GetInt32(0),
                                descripcion = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                                monto_por_hora = reader.IsDBNull(2) ? 0 : reader.GetDecimal(2),
                                Codigo = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                                // 🔹 Aquí validamos id_reserva, pero nunca lo dejamos nulo
                                id_reserva = reader.IsDBNull(4) ? 0 : reader.GetInt32(4)
                            };
                        }
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



        public (bool registrado, string idCliente) RegistrarReserva(string placa, int reserva, string tipo_vehiculo, string numeroIdColaborador)
		{
			try
			{
				using (var cn = GetConnection())
				{
					cn.Open();

                    int idVehiculo = 0;
                    string idCliente = null;
                    //consultamos si ya existe
                    using (var cmdCheckVehiculo = new SqlCommand("SELECT id_vehiculo, id_numero FROM Vehiculo WHERE Placa = @Placa", cn))
                    {
                        cmdCheckVehiculo.Parameters.AddWithValue("@Placa", placa);
                        using (var reader = cmdCheckVehiculo.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                idVehiculo = reader.GetInt32(0);
                                if (!reader.IsDBNull(1))
                                    idCliente = reader.GetString(1);
                            }
                        }
                    }


					
                     // 2. Si no existe, registrar vehículo nuevo
                     if (idVehiculo == 0)
                        {
                           string codigoTipoVehiculo;
                           using (var cmdSelect = new SqlCommand("SELECT Codigo FROM TiposVehiculo WHERE Descripcion = @Descripcion", cn))
                           {
                                cmdSelect.Parameters.AddWithValue("@Descripcion", tipo_vehiculo);
                                codigoTipoVehiculo = cmdSelect.ExecuteScalar()?.ToString();
                           }

                           if (string.IsNullOrEmpty(codigoTipoVehiculo))
                               return (false, null);

                           using (var cmdInsertVehiculo = new SqlCommand(@"INSERT INTO Vehiculo (Placa, Codigo) 
                                    VALUES (@Placa, @Codigo);
                            SELECT CAST(SCOPE_IDENTITY() AS INT);", cn))
                            {
                                cmdInsertVehiculo.Parameters.AddWithValue("@Placa", placa);
                                cmdInsertVehiculo.Parameters.AddWithValue("@Codigo", codigoTipoVehiculo);

                                idVehiculo = (int)cmdInsertVehiculo.ExecuteScalar();
                            }
                     }

                    


                    using (var cmdInsertEntrada = new SqlCommand(@"INSERT INTO Entrada (fecha_hora_entrada, id_vehiculo, numero_id, id_numero)  
                            VALUES (GETDATE(), @IdVehiculo, @NumeroId, @IdCliente)", cn))
                    {
                        cmdInsertEntrada.Parameters.AddWithValue("@IdVehiculo", idVehiculo);
                        cmdInsertEntrada.Parameters.AddWithValue("@NumeroId", numeroIdColaborador);

                        if (idCliente != null)
                            cmdInsertEntrada.Parameters.AddWithValue("@IdCliente", idCliente);
                        else
                            cmdInsertEntrada.Parameters.AddWithValue("@IdCliente", DBNull.Value);

                        bool exito = cmdInsertEntrada.ExecuteNonQuery() > 0;
                        return (exito, idCliente);
                    }
                }

			}
			catch (Exception)
			{

				throw;
			}
		}

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

        public (bool registrado, string idCliente, DateTime fechaEntrada, DateTime fechaSalida, decimal total) RegistrarSalidaReserva(string placa, string numeroIdColaborador, decimal total)
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
                            string idCliente = null;
                            DateTime fechaEntrada;

                            // 1. Buscar entrada activa con cliente
                            using (var command = new SqlCommand(@"SELECT TOP 1 e.id_entrada, v.Codigo, e.id_numero, e.fecha_hora_entrada
                                                                FROM Entrada e 
                                                                INNER JOIN Vehiculo v ON v.id_vehiculo = e.id_vehiculo
                                                                LEFT JOIN Salida s ON s.id_entrada = e.id_entrada
                                                                WHERE v.placa = @Placa AND s.id_salida IS NULL
                                                                ORDER BY e.fecha_hora_entrada DESC", cn, tx))
                            {
                                command.Parameters.AddWithValue("@Placa", placa);
                                using (var result = command.ExecuteReader())
                                {
                                    if (!result.Read())
                                        throw new Exception("No existe entrada activa");

                                    idEntrada = result.GetInt32(0);
                                    codigoTipoVehiculo = result.GetString(1);
                                    if (!result.IsDBNull(2))
                                        idCliente = result.GetString(2);
                                    fechaEntrada = result.GetDateTime(3);
                                }
                            }

                            // 2. Obtener tarifa
                            int idTarifa;
                            using (var command = new SqlCommand(@"SELECT TOP 1 id_tarifa 
                                                                    FROM Tarifa
                                                                    WHERE Codigo = @Codigo AND estado = 1", cn, tx))
                            {
                                command.Parameters.AddWithValue("@Codigo", codigoTipoVehiculo);
                                idTarifa = (int)command.ExecuteScalar();
                            }

                            // 3. Registrar salida
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

                            return (true, idCliente, fechaEntrada, DateTime.Now, total);
                        }
                        catch
                        {
                            tx.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }


        public (int idEntrada, DateTime fechaEntrada, ETarifa tarifa) ObtenerInfoReserva(string placa)
        {
            try
            {
                using (var cn = GetConnection())
                {
                    cn.Open();

                    using (var command = new SqlCommand(@"
                SELECT TOP 1
    e.id_entrada,
    e.fecha_hora_entrada,
    t.id_tarifa,
    t.monto_por_hora
FROM Entrada e 
INNER JOIN Vehiculo v ON v.id_vehiculo = e.id_vehiculo
INNER JOIN Tarifa t ON t.Codigo = v.Codigo AND t.estado = 1
LEFT JOIN Salida s ON s.id_entrada = e.id_entrada
WHERE v.placa = @Placa AND s.id_salida IS NULL
ORDER BY e.fecha_hora_entrada DESC
", cn))
                    {
                        command.Parameters.AddWithValue("@Placa", placa);

                        using (var r = command.ExecuteReader())
                        {
                            if (!r.Read())
                                throw new Exception("No existe entrada activa o tarifa asociada.");

                            return (
                                r.GetInt32(0),          // id_entrada
                                r.GetDateTime(1),       // fecha_hora_entrada
                                new ETarifa
                                {
                                    id_tarifa = r.GetInt32(2),
                                    monto_por_hora = r.GetDecimal(3),
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

    }
}
