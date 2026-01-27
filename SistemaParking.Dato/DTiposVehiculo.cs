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
    public class DTiposVehiculo : ConnectionSql
    {
        //Listar los tipos de vehiculos para el combobox
        public List<ETiposVehiculo> GetTiposVehiculos()
        {
            try
            {
                var lista = new List<ETiposVehiculo>();

                using (var cn = GetConnection())
                {
                    cn.Open();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = cn;
                        command.CommandText = "SELECT * FROM TiposVehiculo";
                        command.CommandType = CommandType.Text;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var tipovehiculo = new ETiposVehiculo
                                {
                                    Codigo = reader.GetString(0),
                                    Descripcion = reader.GetString(1)
                                };
                                lista.Add(tipovehiculo);
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
