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
    public class DColor : ConnectionSql
    {
        //Listar los tipos de vehiculos para el combobox
        public List<EColor> GetColor()
        {
            try
            {
                var lista = new List<EColor>();

                using (var cn = GetConnection())
                {
                    cn.Open();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = cn;
                        command.CommandText = "SELECT * FROM Color";
                        command.CommandType = CommandType.Text;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var color = new EColor
                                {
                                    id_color = reader.GetInt32(0),
                                    nombre_color = reader.GetString(1)
                                };
                                lista.Add(color);
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
