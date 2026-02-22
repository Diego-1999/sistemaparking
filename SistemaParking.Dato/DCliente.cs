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

        
        // Mostrar todos los clientes con sus vehículos

        public List<ECliente> MostrarClientes()
        {
            List<ECliente> clientes = new List<ECliente>();

            using (var cn = GetConnection())
            {
                cn.Open();
                using (var cmd = new SqlCommand(@"
            SELECT c.id_numero, c.tipo_id, c.nombre, c.apellido, cc.telefono, cc.correo,
                   v.id_vehiculo, v.placa, v.Codigo, tv.Descripcion AS TipoVehiculo,
                   m.nombre_marca, col.nombre_color
            FROM Cliente c
            INNER JOIN ContactoCliente cc ON c.id_numero = cc.id_numero
            INNER JOIN Vehiculo v ON c.id_numero = v.id_numero
            INNER JOIN TiposVehiculo tv ON v.Codigo = tv.Codigo
            INNER JOIN Marca m ON v.id_marca = m.id_marca
            INNER JOIN Color col ON v.id_color = col.id_color;", cn))

                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string cedula = reader["id_numero"].ToString();

                            // Buscar si ya existe el cliente en la lista
                            var cliente = clientes.FirstOrDefault(c => c.Cedula == cedula);

                            if (cliente == null)
                            {
                                cliente = new ECliente
                                {
                                    Cedula = cedula,
                                    TipoId = reader["tipo_id"].ToString(),
                                    Nombre = reader["nombre"].ToString(),
                                    Apellido = reader["apellido"].ToString(),
                                    Telefono = reader["telefono"].ToString(),
                                    Correo = reader["correo"].ToString(),
                                    Vehiculos = new List<EVehiculo>()
                                };
                                clientes.Add(cliente);
                            }

                            // Agregar el vehículo a la lista del cliente
                            cliente.Vehiculos.Add(new EVehiculo
                            {
                                IdVehiculo = Convert.ToInt32(reader["id_vehiculo"]),
                                Placa = reader["placa"].ToString(),
                                Codigo = reader["Codigo"].ToString(),
                                TipoVehiculo = reader["TipoVehiculo"].ToString(),
                                Marca = reader["nombre_marca"].ToString(),
                                Color = reader["nombre_color"].ToString()

                            });
                        }
                    }
                }
            }
            return clientes;
        }



        public List<ECliente> BuscarClientes(string busqueda)
        {
            List<ECliente> clientes = new List<ECliente>();

            using (var cn = GetConnection())
            {
                cn.Open();
                using (var cmd = new SqlCommand(@"
                 SELECT c.id_numero, c.tipo_id, c.nombre, c.apellido, cc.telefono, cc.correo,
                        v.id_vehiculo, v.placa, v.Codigo, tv.Descripcion AS TipoVehiculo,
                        m.nombre_marca, col.nombre_color
                 FROM Cliente c
                 INNER JOIN ContactoCliente cc ON c.id_numero = cc.id_numero
                 INNER JOIN Vehiculo v ON c.id_numero = v.id_numero
                 INNER JOIN TiposVehiculo tv ON v.Codigo = tv.Codigo
                 INNER JOIN Marca m ON v.id_marca = m.id_marca
                 INNER JOIN Color col ON v.id_color = col.id_color
                 WHERE c.nombre LIKE '%' + @Busqueda + '%' OR c.apellido LIKE '%' + @Busqueda + '%';", cn))
                {
                    cmd.Parameters.AddWithValue("@Busqueda", busqueda);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string cedula = reader["id_numero"].ToString();

                            // Buscar si ya existe el cliente en la lista
                            var cliente = clientes.FirstOrDefault(c => c.Cedula == cedula);

                            if (cliente == null)
                            {
                                cliente = new ECliente
                                {
                                    Cedula = cedula,
                                    TipoId = reader["tipo_id"].ToString(),
                                    Nombre = reader["nombre"].ToString(),
                                    Apellido = reader["apellido"].ToString(),
                                    Telefono = reader["telefono"].ToString(),
                                    Correo = reader["correo"].ToString(),
                                    Vehiculos = new List<EVehiculo>()
                                };
                                clientes.Add(cliente);
                            }

                            // Bloque para agregar el vehículo
                            cliente.Vehiculos.Add(new EVehiculo
                            {
                                IdVehiculo = Convert.ToInt32(reader["id_vehiculo"]),
                                Placa = reader["placa"].ToString(),
                                Codigo = reader["Codigo"].ToString(),
                                TipoVehiculo = reader["TipoVehiculo"].ToString(),
                                Marca = reader["nombre_marca"].ToString(),
                                Color = reader["nombre_color"].ToString()
                            });
                        }
                    }
                }
            }
            return clientes;
        }

        //Llamar al Padron electotoral al registrar un cliente
        public ECliente BuscarPadronElectoral(string cedula)
        {
            using (var cn = GetConnection())
            {
                cn.Open();
                using (var cmd = new SqlCommand(
                    @"SELECT CEDULA, NOMBRE, PRIMER_APELLIDO, SEGUNDO_APELLIDO
                    FROM PADRON_ELECTORAL
                    WHERE CEDULA = @cedula", cn))
                {
                    cmd.Parameters.AddWithValue("@cedula", cedula);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ECliente
                            {
                                Cedula = reader.GetString(0),
                                Nombre = reader.GetString(1),
                                Apellido = reader.GetString(2) + " " + reader.GetString(3)
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
