using SistemaParking.Datos;
using System;
using System.Collections.Generic;
using System.Data;
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
                    if (string.IsNullOrEmpty(codigoTipoId)) //validamos si obtuvimos el id del tipo id
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

                    if (string.IsNullOrEmpty(codigoTipoVehiculo)) // validamos si obtuvimos el id del tipo vehiculo
                        return false;


                    //Obtener marcar
                    string codigoMarca;
                    using (var cmdMarca = new SqlCommand("SELECT id_marca FROM Marca WHERE nombre_marca = @nombre_marca", cn))
                    {
                        cmdMarca.Parameters.AddWithValue("@nombre_marca", marca);
                        codigoMarca = cmdMarca.ExecuteScalar()?.ToString();
                    }

                    if (string.IsNullOrEmpty(codigoMarca)) // validamos si obtuvimos el id de marca
                        return false;


                    //Obtener color
                    string codigoColor;
                    using (var cmdColor = new SqlCommand("SELECT id_color FROM Color WHERE nombre_color = @nombre_color", cn))
                    {
                        cmdColor.Parameters.AddWithValue("@nombre_color", color);
                        codigoColor = cmdColor.ExecuteScalar()?.ToString();
                    }

                    if (string.IsNullOrEmpty(codigoColor)) // validamos si obtuvimos el id del color
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

        //Metodo para buscar los clientes
        public DataTable BuscarClientes(string busqueda)
        {
            using (var cn = GetConnection())
            {
                cn.Open();


                //Se realiza la consulta a la base de datos uniendo las tablas relacionadas
                using (var cmd = new SqlCommand(@"SELECT c.id_numero AS Cedula, c.nombre AS Nombre, c.apellido AS Apellido, v.placa, tv.Descripcion AS TipoVehiculo, m.nombre_marca AS Marca, col.nombre_color AS Color 
                 FROM Cliente c INNER JOIN Vehiculo v on c.id_numero = v.id_numero
                 INNER JOIN TiposVehiculo tv ON v.Codigo = tv.Codigo
                 INNER JOIN Marca m ON v.id_marca = m.id_marca
                 INNER JOIN Color col ON v.id_color = col.id_color
                 WHERE c.id_numero = @Busqueda OR c.nombre LIKE '%' + @Busqueda + '%'", cn))
                {

                    cmd.Parameters.AddWithValue("@Busqueda", busqueda);

                    //Ejecutar la consulta y llenar el DataTable con los resultados
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    //Retorna el DataTable para que se pueda usar en la capa presentacion 
                    return dt;

                }
            }
        }
        public DataTable MostrarClientes()
        {
            using (var cn = GetConnection())
            {
                cn.Open();

                using (var cmd = new SqlCommand(@"SELECT c.id_numero AS Cedula, c.nombre AS Nombre, c.apellido AS Apellido, v.placa, tv.Descripcion AS TipoVehiculo, m.nombre_marca AS Marca, col.nombre_color AS Color 
                 FROM Cliente c INNER JOIN Vehiculo v on c.id_numero = v.id_numero
                 INNER JOIN TiposVehiculo tv ON v.Codigo = tv.Codigo
                 INNER JOIN Marca m ON v.id_marca = m.id_marca
                 INNER JOIN Color col ON v.id_color = col.id_color", cn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }

            }
        }
    }
}
