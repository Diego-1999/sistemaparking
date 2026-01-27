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
    public class DTipoID : ConnectionSql
    {
        //Listar los tipos de identificacion para el combobox
        public List<ETipoId> GetTipoId()
        {
            try
            {
                var lista = new List<ETipoId>();

                using (var cn = GetConnection())
                {
                    cn.Open();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = cn;
                        command.CommandText = "SELECT * FROM TipoID";
                        command.CommandType = CommandType.Text;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var tipoID = new ETipoId
                                {
                                    tipo_id = reader.GetString(0),
                                    descripcion = reader.GetString(1)
                                };
                                lista.Add(tipoID);
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
