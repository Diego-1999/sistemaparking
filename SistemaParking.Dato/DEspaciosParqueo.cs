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


        // Método original (si lo usas en otros lugares)
        public int ObtenerEspaciosDisponibles(string codigoTipoVehiculo, int totalEspacios)
        {
            using (var cn = GetConnection())
            {
                cn.Open();
                using (var cmd = new SqlCommand(@"
         SELECT COUNT(*)  
         FROM Entrada e  
         INNER JOIN Vehiculo v ON v.id_vehiculo = e.id_vehiculo  
         LEFT JOIN Salida s ON s.id_entrada = e.id_entrada  
         WHERE v.Codigo = @Codigo AND s.id_salida IS NULL", cn))
                {
                    cmd.Parameters.AddWithValue("@Codigo", codigoTipoVehiculo);
                    int ocupados = (int)cmd.ExecuteScalar();
                    return totalEspacios - ocupados;
                }
            }
        }

        // Nuevo método: devuelve ocupados por un código específico
        public int ObtenerOcupadosPorCodigo(string codigoTipoVehiculo)
        {
            using (var cn = GetConnection())
            {
                cn.Open();
                using (var cmd = new SqlCommand(@"
         SELECT COUNT(*)  
         FROM Entrada e  
         INNER JOIN Vehiculo v ON v.id_vehiculo = e.id_vehiculo  
         LEFT JOIN Salida s ON s.id_entrada = e.id_entrada  
         WHERE v.Codigo = @Codigo AND s.id_salida IS NULL", cn))
                {
                    cmd.Parameters.AddWithValue("@Codigo", codigoTipoVehiculo);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

    }
}
