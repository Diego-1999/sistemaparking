using SistemaParking.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParking.Dato
{
    public class DEntradaVehiculo: ConnectionSql 
    {
        public bool RegistrarVehiculo(string placa, string nombreTipoVehiculo, string numeroIdColaborador)
        {
            try
            {
                using (var cn = GetConnection())
                {
                    cn.Open();

                    int idVehiculo = 0;
                    string idCliente = null;

                    // 1. Verificar si el vehículo ya existe
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
                            cmdSelect.Parameters.AddWithValue("@Descripcion", nombreTipoVehiculo);
                            codigoTipoVehiculo = cmdSelect.ExecuteScalar()?.ToString();
                        }

                        if (string.IsNullOrEmpty(codigoTipoVehiculo))
                            return false;

                        using (var cmdInsertVehiculo = new SqlCommand(@"INSERT INTO Vehiculo (Placa, Codigo) 
                            VALUES (@Placa, @Codigo);
                            SELECT CAST(SCOPE_IDENTITY() AS INT);", cn))
                        {
                            cmdInsertVehiculo.Parameters.AddWithValue("@Placa", placa);
                            cmdInsertVehiculo.Parameters.AddWithValue("@Codigo", codigoTipoVehiculo);

                            idVehiculo = (int)cmdInsertVehiculo.ExecuteScalar();
                        }
                    }

                    // 3. Insertar entrada (con cliente si existe)
                    using (var cmdInsertEntrada = new SqlCommand(@"INSERT INTO Entrada (fecha_hora_entrada, id_vehiculo, numero_id, id_numero) 
                        VALUES (GETDATE(), @IdVehiculo, @NumeroId, @IdCliente)", cn))
                    {
                        cmdInsertEntrada.Parameters.AddWithValue("@IdVehiculo", idVehiculo);
                        cmdInsertEntrada.Parameters.AddWithValue("@NumeroId", numeroIdColaborador);

                        if (idCliente != null)
                            cmdInsertEntrada.Parameters.AddWithValue("@IdCliente", idCliente);
                        else
                            cmdInsertEntrada.Parameters.AddWithValue("@IdCliente", DBNull.Value);

                        return cmdInsertEntrada.ExecuteNonQuery() > 0;
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














        //public bool RegistrarVehiculo(string placa, string nombreTipoVehiculo, string numeroIdColaborador)
        //{
        //    try
        //    {
        //        using (var cn = GetConnection())
        //        {
        //            cn.Open();

        //            // 1. Obtener código del tipo de vehículo
        //            string codigoTipoVehiculo;
        //            using (var cmdSelect = new SqlCommand("SELECT Codigo FROM TiposVehiculo WHERE Descripcion = @Descripcion", cn))
        //            {
        //                cmdSelect.Parameters.AddWithValue("@Descripcion", nombreTipoVehiculo);
        //                codigoTipoVehiculo = cmdSelect.ExecuteScalar()?.ToString();
        //            }

        //            if (string.IsNullOrEmpty(codigoTipoVehiculo))
        //                return false;

        //            // 2. Insertar vehículo y obtener ID
        //            int idVehiculo;
        //            using (var cmdInsertVehiculo = new SqlCommand(@"INSERT INTO Vehiculo (Placa, Codigo) VALUES (@Placa, @Codigo);
        //                    SELECT CAST(SCOPE_IDENTITY() AS INT);", cn))
        //            {
        //                cmdInsertVehiculo.Parameters.AddWithValue("@Placa", placa);
        //                cmdInsertVehiculo.Parameters.AddWithValue("@Codigo", codigoTipoVehiculo);

        //                idVehiculo = (int)cmdInsertVehiculo.ExecuteScalar();
        //            }

        //            // 3. Insertar entrada
        //            using (var cmdInsertEntrada = new SqlCommand( @"INSERT INTO Entrada (fecha_hora_entrada, id_vehiculo, numero_id)
        //                    VALUES (GETDATE(), @IdVehiculo, @NumeroId)", cn))
        //            {
        //                cmdInsertEntrada.Parameters.AddWithValue("@IdVehiculo", idVehiculo);
        //                cmdInsertEntrada.Parameters.AddWithValue("@NumeroId", numeroIdColaborador);

        //                return cmdInsertEntrada.ExecuteNonQuery() > 0;
        //            }
        //        }
        //    }
        //    catch (SqlException sqlex)
        //    {
        //        throw sqlex;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



    }


}

