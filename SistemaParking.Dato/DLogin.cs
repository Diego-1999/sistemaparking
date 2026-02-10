using SistemaParking.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaParking.Entidad;

namespace SistemaParking.Datos
{
    public class DLogin : ConnectionSql
    {

        public UsuarioSesion Login(string user)
        {
            using (var cn = GetConnection())
            {
                cn.Open();
                using (var command = new SqlCommand(@"SELECT u.id_usuario, u.usuario, 
                                                    u.id_rol, r.nombre_rol, 
                                                    u.numero_id, 
                                                    u.contrasena_hash, 
                                                    u.salt, 
                                                    u.iteraciones
                                             FROM Usuario u
                                             INNER JOIN Rol r ON u.id_rol = r.id_rol
                                             WHERE u.usuario = @user", cn))
                {
                    command.Parameters.AddWithValue("@user", user);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new UsuarioSesion
                            {
                                IdUsuario = reader.GetInt32(0),
                                Usuario = reader.GetString(1),
                                IdRol = reader.GetInt32(2),
                                NombreRol = reader.GetString(3),
                                NumeroIdColaborador = reader.GetString(4),
                                ContrasenaHash = (byte[])reader["contrasena_hash"],
                                Salt = (byte[])reader["salt"],
                                Iteraciones = (int)reader["iteraciones"]
                            };
                        }
                    }
                }
            }
            return null;
        }
    }

}
