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
        public bool RegistrarUsuario(string tipoid, string nombre, string apellido, string telefono,string cedula, string correo, string usuario,
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
    }
}
