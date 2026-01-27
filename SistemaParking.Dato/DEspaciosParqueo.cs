using SistemaParking.Datos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParking.Dato
{
    public class DEspaciosParqueo: ConnectionSql
    {
        public bool EstablecerEspacios(int numeroEspacio, string tipoEspacio)
        {
			try
			{
				using (var cn = GetConnection())
				{
					cn.Open();

					using (var cmdInsertarEspacios = new SqlCommand(@"INSERT INTO Parqueo(numero_espacio, tipo_espacio)
						VALUES (@numero_espacio, @tipo_espacio)", cn))
					{
						cmdInsertarEspacios.Parameters.AddWithValue("@numero_espacio",numeroEspacio);
                        cmdInsertarEspacios.Parameters.AddWithValue("@tipo_espacio",tipoEspacio);

						return cmdInsertarEspacios.ExecuteNonQuery() > 0;
                    }
				}
			}
            catch (SqlException )
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
