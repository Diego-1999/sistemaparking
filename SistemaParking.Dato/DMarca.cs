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
        public List<EMarca> GetTiposDeMarca()
        {
            var lista = new List<EMarca>();
            using (var cn = GetConnection())
            {
                cn.Open();
                using (var command = new SqlCommand("SELECT id_marca, nombre_marca FROM Marca", cn))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new EMarca
                        {
                            id_marca = reader.GetInt32(reader.GetOrdinal("id_marca")),
                            nombre_marca = reader.GetString(reader.GetOrdinal("nombre_marca"))
                        });
                    }
                }
            }
            return lista;
        }
    }
}
