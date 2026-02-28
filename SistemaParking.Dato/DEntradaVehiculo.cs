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


        public (bool registrado, string idCliente) RegistrarVehiculo(string placa, string nombreTipoVehiculo, string numeroIdColaborador)
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

                        bool exito = cmdInsertEntrada.ExecuteNonQuery() > 0;
                        return (exito, idCliente);
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

        public bool RegistrarSegundoVehiculo(string placa, string nombreTipoVehiculo, string numeroIdCliente, string marca, string color)
        {
            try
            {
                using (var cn = GetConnection())
                {
                    cn.Open();

                    // 1. Obtener código del tipo de vehículo
                    string codigoTipoVehiculo;
                    using (var cmdSelect = new SqlCommand(
                        "SELECT Codigo FROM TiposVehiculo WHERE Descripcion = @Descripcion", cn))
                    {
                        cmdSelect.Parameters.AddWithValue("@Descripcion", nombreTipoVehiculo);
                        codigoTipoVehiculo = cmdSelect.ExecuteScalar()?.ToString();
                    }
                    if (string.IsNullOrEmpty(codigoTipoVehiculo))
                        return false;

                    //Obtener marcar
                    string codigoMarca;
                    using (var cmdMarca = new SqlCommand(
                        "SELECT id_marca FROM Marca WHERE nombre_marca = @nombre_marca", cn))
                    {
                        cmdMarca.Parameters.AddWithValue("@nombre_marca", marca);
                        codigoMarca = cmdMarca.ExecuteScalar()?.ToString();
                    }

                    if (string.IsNullOrEmpty(codigoMarca))
                        return false;


                    //Obtener color
                    string codigoColor;
                    using (var cmdColor = new SqlCommand(
                        "SELECT id_color FROM Color WHERE nombre_color = @nombre_color", cn))
                    {
                        cmdColor.Parameters.AddWithValue("@nombre_color", color);
                        codigoColor = cmdColor.ExecuteScalar()?.ToString();
                    }

                    if (string.IsNullOrEmpty(codigoColor))
                        return false;

                    // Insertar vehículo asociado al cliente
                    using (var cmdVehiculo = new SqlCommand(
                      @"INSERT INTO Vehiculo (Placa, Codigo, id_numero, id_marca, id_color) 
                        VALUES (@Placa, @Codigo, @IdNumero, @id_marca, @id_color)", cn))
                    {
                        cmdVehiculo.Parameters.AddWithValue("@Placa", placa);
                        cmdVehiculo.Parameters.AddWithValue("@Codigo", codigoTipoVehiculo);
                        cmdVehiculo.Parameters.AddWithValue("@IdNumero", numeroIdCliente);
                        cmdVehiculo.Parameters.AddWithValue("@id_marca", codigoMarca);
                        cmdVehiculo.Parameters.AddWithValue("@id_color", codigoColor);
                        cmdVehiculo.ExecuteNonQuery();
                    }

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }


        public string ObtenerIdClientePorPlaca(string placa)
        {
            using (var cn = GetConnection())
            {
                cn.Open();
                using (var cmd = new SqlCommand("SELECT id_numero FROM Vehiculo WHERE Placa = @Placa", cn))
                {
                    cmd.Parameters.AddWithValue("@Placa", placa);
                    var result = cmd.ExecuteScalar();
                    return result?.ToString();
                }
            }
        }
    }
}

