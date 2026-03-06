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
    public class DUsuario : ConnectionSql
    {
        public bool RegistrarUsuario(string tipoid, string nombre, string apellido, string telefono, string cedula, string correo, string usuario,
                                    string contrasenaHash, string salt, int iteraciones, string rol)
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

                    // Insertar Colaborador
                    using (var cmdColaborador = new SqlCommand(@"INSERT INTO Colaborador (numero_id, tipo_id, nombre, apellido)  
                 VALUES (@NumeroId, @TipoId, @Nombre, @Apellido)", cn))
                    {
                        cmdColaborador.Parameters.AddWithValue("@NumeroID", cedula);
                        cmdColaborador.Parameters.AddWithValue("@TipoID", codigoTipoId);
                        cmdColaborador.Parameters.AddWithValue("@Nombre", nombre);
                        cmdColaborador.Parameters.AddWithValue("@Apellido", apellido);
                        cmdColaborador.ExecuteNonQuery();
                    }

                    //Insertar Contacto colaborador 
                    using (var cmdContactoColaborador = new SqlCommand(@"INSERT INTO ContactoColaborador ( numero_id ,telefono, correo)
                 VALUES ( @NumeroID, @Telefono, @Correo)", cn))
                    {
                        cmdContactoColaborador.Parameters.AddWithValue("@NumeroID", cedula);
                        cmdContactoColaborador.Parameters.AddWithValue("@Telefono", telefono);
                        cmdContactoColaborador.Parameters.AddWithValue("@Correo", correo);
                        cmdContactoColaborador.ExecuteNonQuery();
                    }

                    //Obtener Rol
                    string CodigoRol;
                    using (var cmdRol = new SqlCommand("SELECT id_rol FROM Rol WHERE nombre_rol = @nombre_rol", cn))
                    {
                        cmdRol.Parameters.AddWithValue("@nombre_rol", rol);
                        CodigoRol = cmdRol.ExecuteScalar()?.ToString();
                    }
                    if (string.IsNullOrEmpty(CodigoRol))
                    {
                        return false;
                    }

                    // Insertar Usuario
                    using (var cmdUsuario = new SqlCommand(@"INSERT INTO Usuario (usuario, contrasena_hash, salt, iteraciones, id_rol, numero_id)
                   VALUES (@Usuario, @ContrasenaHash, @Salt, @Iteraciones, @id_rol, @NumeroID)", cn))
                    {
                        cmdUsuario.Parameters.AddWithValue("@Usuario", usuario);
                        cmdUsuario.Parameters.AddWithValue("@ContrasenaHash", Convert.FromBase64String(contrasenaHash));
                        cmdUsuario.Parameters.AddWithValue("@Salt", Convert.FromBase64String(salt));
                        cmdUsuario.Parameters.AddWithValue("@Iteraciones", iteraciones);
                        cmdUsuario.Parameters.AddWithValue("@id_rol", CodigoRol);
                        cmdUsuario.Parameters.AddWithValue("@NumeroID", cedula);
                        cmdUsuario.ExecuteNonQuery();
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


        //Mostrar los usuarios en el DataGridView
        public List<EUsuario> MostrarUsuarios()
        {
            List<EUsuario> usuarios = new List<EUsuario>();

            using (var cn = GetConnection())
            {
                cn.Open();
                using (var cmd = new SqlCommand(@"
            SELECT c.numero_id, c.tipo_id, t.descripcion AS TipoIdentificacion,
                   c.nombre, c.apellido,
                   u.usuario, u.contrasena_hash, u.id_rol, r.nombre_rol,
                   cc.telefono, cc.correo
            FROM Usuario u
            INNER JOIN Colaborador c ON u.numero_id = c.numero_id
            INNER JOIN ContactoColaborador cc ON c.numero_id = cc.numero_id
            INNER JOIN Rol r ON u.id_rol = r.id_rol
            INNER JOIN TipoID t ON c.tipo_id = t.tipo_id;", cn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuarios.Add(new EUsuario
                            {
                                numero_id = reader["numero_id"].ToString(),
                                tipo_id = reader["tipo_id"].ToString(),
                                TipoIdentificacion = reader["TipoIdentificacion"].ToString(),
                                nombre = reader["nombre"].ToString(),
                                apellido = reader["apellido"].ToString(),
                                usuario = reader["usuario"].ToString(),
                                Contrasena = reader["contrasena_hash"].ToString(),
                                telefono = reader["telefono"].ToString(),
                                correo = reader["correo"].ToString(),
                                IdRol = Convert.ToInt32(reader["id_rol"]),
                                Rol = reader["nombre_rol"].ToString()
                            });
                        }
                    }
                }
            }
            return usuarios;
        }

        public List<EUsuario> BuscarUsuarios(string criterio)
        {
            List<EUsuario> usuarios = new List<EUsuario>();

            using (var cn = GetConnection())
            {
                cn.Open();
                using (var cmd = new SqlCommand(@"
             SELECT c.numero_id, c.tipo_id, c.nombre, c.apellido,
                    u.usuario,
                    cc.telefono, cc.correo
             FROM Usuario u
             INNER JOIN Colaborador c ON u.numero_id = c.numero_id                    
             INNER JOIN ContactoColaborador cc ON c.numero_id = cc.numero_id
             WHERE c.nombre LIKE '%' + @criterio + '%'
                OR c.apellido LIKE '%' + @criterio + '%'
                OR c.numero_id LIKE '%' + @criterio + '%';", cn))
                {
                    cmd.Parameters.AddWithValue("@criterio", criterio);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuarios.Add(new EUsuario
                            {
                                numero_id = reader["numero_id"].ToString(),
                                tipo_id = reader["tipo_id"].ToString(),
                                nombre = reader["nombre"].ToString(),
                                apellido = reader["apellido"].ToString(),
                                usuario = reader["usuario"].ToString(),
                                telefono = reader["telefono"].ToString(),
                                correo = reader["correo"].ToString()
                            });
                        }
                    }
                }
            }
            return usuarios;
        }

        public bool EliminarUsuario(string cedula)
        {
            using (var cn = GetConnection())
            {
                cn.Open();

                // Eliminar usuario primero (porque depende de Colaborador)
                using (var cmdUsuario = new SqlCommand("DELETE FROM Usuario WHERE numero_id = @cedula", cn))
                {
                    cmdUsuario.Parameters.AddWithValue("@cedula", cedula);
                    cmdUsuario.ExecuteNonQuery();
                }

                // Eliminar contacto
                using (var cmdContacto = new SqlCommand("DELETE FROM ContactoColaborador WHERE numero_id = @cedula", cn))
                {
                    cmdContacto.Parameters.AddWithValue("@cedula", cedula);
                    cmdContacto.ExecuteNonQuery();
                }

                // Eliminar colaborador
                using (var cmdColaborador = new SqlCommand("DELETE FROM Colaborador WHERE numero_id = @cedula", cn))
                {
                    cmdColaborador.Parameters.AddWithValue("@cedula", cedula);
                    int filas = cmdColaborador.ExecuteNonQuery();
                    return filas > 0;
                }

            }
        }


        public bool ActualizarUsuario(EUsuario usuario)
        {
            using (var cn = GetConnection())
            {
                cn.Open();
                using (var tran = cn.BeginTransaction())
                {
                    try
                    {
                        // Actualizar Colaborador
                        using (var cmdColaborador = new SqlCommand(@"
                     UPDATE Colaborador
                     SET tipo_id = @TipoId,
                         nombre = @Nombre,
                         apellido = @Apellido
                     WHERE numero_id = @NumeroID", cn, tran))
                        {
                            cmdColaborador.Parameters.AddWithValue("@NumeroID", usuario.numero_id);
                            cmdColaborador.Parameters.AddWithValue("@TipoId", usuario.tipo_id);
                            cmdColaborador.Parameters.AddWithValue("@Nombre", usuario.nombre);
                            cmdColaborador.Parameters.AddWithValue("@Apellido", usuario.apellido);
                            cmdColaborador.ExecuteNonQuery();
                        }

                        // Actualizar ContactoColaborador
                        using (var cmdContacto = new SqlCommand(@"
                     UPDATE ContactoColaborador
                     SET telefono = @Telefono,
                         correo = @Correo
                     WHERE numero_id = @NumeroID", cn, tran))
                        {
                            cmdContacto.Parameters.AddWithValue("@NumeroID", usuario.numero_id);
                            cmdContacto.Parameters.AddWithValue("@Telefono", usuario.telefono);
                            cmdContacto.Parameters.AddWithValue("@Correo", usuario.correo);
                            cmdContacto.ExecuteNonQuery();
                        }

                        // Actualizar Usuario
                        using (var cmdUsuario = new SqlCommand(@"
                     UPDATE Usuario
                     SET usuario = @Usuario,
                         contrasena_hash = @Contrasena,
                         salt = @Salt,
                         iteraciones = @Iteraciones,
                         id_rol = @IdRol
                     WHERE numero_id = @NumeroID", cn, tran))
                        {
                            cmdUsuario.Parameters.AddWithValue("@Usuario", usuario.usuario);

                            // Convertir Base64 a binario para VARBINARY
                            byte[] hashBytes = Convert.FromBase64String(usuario.Contrasena);
                            cmdUsuario.Parameters.Add("@Contrasena", SqlDbType.VarBinary, hashBytes.Length).Value = hashBytes;

                            // Salt también es binario
                            byte[] saltBytes = Convert.FromBase64String(usuario.Salt);
                            cmdUsuario.Parameters.Add("@Salt", SqlDbType.VarBinary, saltBytes.Length).Value = saltBytes;

                            cmdUsuario.Parameters.AddWithValue("@Iteraciones", usuario.Iteraciones);
                            cmdUsuario.Parameters.AddWithValue("@IdRol", usuario.IdRol);
                            cmdUsuario.Parameters.AddWithValue("@NumeroID", usuario.numero_id);

                            cmdUsuario.ExecuteNonQuery();
                        }

                        tran.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw new Exception("Error al actualizar usuario: " + ex.Message, ex);
                    }
                }
            }
        }
    }
}
