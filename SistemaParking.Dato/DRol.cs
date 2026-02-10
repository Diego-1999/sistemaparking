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
    public class DRol : ConnectionSql
    {
            //Listar los tipos de vehiculos para el combobox
            public List<ERol> GetRol()
            {
            try
            {
                var lista = new List<ERol>();

                using (var cn = GetConnection())
                {
                    cn.Open();
                    using (var command = new SqlCommand("SELECT * FROM Rol", cn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var rol = new ERol
                                {
                                    id_rol = reader.GetInt32(0),
                                    nombre_rol = reader.GetString(1)
                                };
                                lista.Add(rol);
                            }
                        }

                    }
                }
                return lista;
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
