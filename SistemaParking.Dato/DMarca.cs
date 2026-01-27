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
    public class DMarca : ConnectionSql
    {
        //Listar los tipos de vehiculos para el combobox
        public List<EMarca> GetMarca()
        {
            try
            {
                var lista = new List<EMarca>();

                using (var cn = GetConnection())
                {
                    cn.Open();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = cn;
                        command.CommandText = "SELECT * FROM Marca";
                        command.CommandType = CommandType.Text;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var marca = new EMarca
                                {
                                    id_marca = reader.GetInt32(0),
                                    nombre_marca = reader.GetString(1)
                                };
                                lista.Add(marca);
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
