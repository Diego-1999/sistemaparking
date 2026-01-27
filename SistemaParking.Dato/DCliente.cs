using SistemaParking.Datos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParking.Dato
{
    public class DCliente : ConnectionSql
    {
        public bool RegistrarCliente(string tipoid,string cedula,string nombre,string apellidos,string telefono,string correo,
            string placa,string nombreTipoVehiculo,string marca,string color)
        {
            try
            {
                using (var cn = GetConnection())
                {
                    cn.Open();

                    // Obtener TipoId
                    string codigoTipoId;
                    using (var cmdTipoId = new SqlCommand("SELECT tipo_id FROM TipoID WHERE tipo_id = @TipoId", cn))
                    {
                        cmdTipoId.Parameters.AddWithValue("@TipoId", tipoid);
                        codigoTipoId = cmdTipoId.ExecuteScalar()?.ToString();
                    }
                    if (string.IsNullOrEmpty(codigoTipoId))
                        return false;

                    // Insertar cliente
                    using (var cmdCLiente = new SqlCommand(@"INSERT INTO Cliente (id_numero, tipo_id, nombre, apellido) 
                        VALUES (@IdNumero, @TipoId, @Nombre, @Apellido)", cn))
                    {
                        cmdCLiente.Parameters.AddWithValue("@IdNumero", cedula);
                        cmdCLiente.Parameters.AddWithValue("@TipoId", codigoTipoId);
                        cmdCLiente.Parameters.AddWithValue("@Nombre", nombre);
                        cmdCLiente.Parameters.AddWithValue("@Apellido", apellidos);
                        cmdCLiente.ExecuteNonQuery();

                    }

                    //Insertar contacto cliente
                    using (var cmdContactoCliente = new SqlCommand(@"INSERT INTO ContactoCliente (id_numero, telefono, correo) 
                        VALUES (@IdNumero, @Telefono, @Correo)", cn))
                    {
                        cmdContactoCliente.Parameters.AddWithValue("@IdNumero", cedula);
                        cmdContactoCliente.Parameters.AddWithValue("@Telefono", telefono);
                        cmdContactoCliente.Parameters.AddWithValue("@Correo", correo);
                        cmdContactoCliente.ExecuteNonQuery();

                    }

                    //Obtener tipo de Vehiculo
                    string codigoTipoVehiculo;
                    using (var cmdSelect = new SqlCommand("SELECT Codigo FROM TiposVehiculo WHERE Descripcion = @Descripcion", cn))
                    {
                        cmdSelect.Parameters.AddWithValue("@Descripcion", nombreTipoVehiculo);
                        codigoTipoVehiculo = cmdSelect.ExecuteScalar()?.ToString();
                    }

                    if (string.IsNullOrEmpty(codigoTipoVehiculo))
                        return false;


                    //Obtener marcar
                    string codigoMarca;
                    using (var cmdMarca = new SqlCommand("SELECT id_marca FROM Marca WHERE nombre_marca = @nombre_marca", cn))
                    {
                        cmdMarca.Parameters.AddWithValue("@nombre_marca", marca);
                        codigoMarca = cmdMarca.ExecuteScalar()?.ToString();
                    }

                    if (string.IsNullOrEmpty(codigoMarca))
                        return false;


                    //Obtener color
                    string codigoColor;
                    using (var cmdColor = new SqlCommand("SELECT id_color FROM Color WHERE nombre_color = @nombre_color", cn))
                    {
                        cmdColor.Parameters.AddWithValue("@nombre_color", color);
                        codigoColor = cmdColor.ExecuteScalar()?.ToString();
                    }

                    if (string.IsNullOrEmpty(codigoColor))
                        return false;

                    //Insertar vehiculo
                    using (var cmdVehiculo = new SqlCommand(@"INSERT INTO Vehiculo (Placa, Codigo, id_numero, id_marca, id_color) 
                        VALUES (@Placa, @Codigo, @IdNumero, @id_marca, @id_color)", cn))
                    {
                        cmdVehiculo.Parameters.AddWithValue("@Placa", placa);
                        cmdVehiculo.Parameters.AddWithValue("@Codigo", codigoTipoVehiculo);
                        cmdVehiculo.Parameters.AddWithValue("@IdNumero", cedula);
                        cmdVehiculo.Parameters.AddWithValue("@id_marca", codigoMarca);
                        cmdVehiculo.Parameters.AddWithValue("@id_color", codigoColor);
                        cmdVehiculo.ExecuteNonQuery();
                    }

                    return true;
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
