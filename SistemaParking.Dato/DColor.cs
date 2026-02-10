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
                var lista = new List<EColor>(); //creamos una lista vacia de tipo EColor y se asigna a la variable

                using (var cn = GetConnection()) //obtenemos la conexion
                {
                    cn.Open(); // abrimos conexion
                    using (var command = new SqlCommand("SELECT * FROM Color", cn)) //se realiza la consulta de tipo SqlCommand y se asigna a command
                    {

                        using (SqlDataReader reader = command.ExecuteReader()) //ejecutamos la consulta y la leemos 
                        {
                            while (reader.Read()) //leemos fila por fila
                            {
                                var color = new EColor
                                {
                                    id_color = reader.GetInt32(0),   //Obtenemos el valor de las columnas y las asignamos al objeto EColor
                                    nombre_color = reader.GetString(1)
                                };
                                lista.Add(color); //agregamos el objeto con los valores a la lista
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








            //Listar los tipos de vehiculos para el combobox
            //public List<EColor> GetColor()
            //{
            //    try
            //    {
            //        var lista = new List<EColor>();

            //        using (var cn = GetConnection())
            //        {
            //            cn.Open();
            //            using (var command = new SqlCommand())
            //            {
            //                command.Connection = cn;
            //                command.CommandText = "SELECT * FROM Color";
            //                command.CommandType = CommandType.Text;
            //                using (SqlDataReader reader = command.ExecuteReader())
            //                {
            //                    while (reader.Read())
            //                    {
            //                        var color = new EColor
            //                        {
            //                            id_color = reader.GetInt32(0),
            //                            nombre_color = reader.GetString(1)
            //                        };
            //                        lista.Add(color);
            //                    }
            //                }

            //            }
            //        }
            //        return lista;
            //    }
            //    catch (SqlException)
            //    {
            //        throw;
            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //    }

            //}
        }
    }
}
