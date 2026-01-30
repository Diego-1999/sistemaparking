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
    public class DReportes : ConnectionSql
    {
        public List<EReportes> ObtenerReporte(DateTime fechaInicial, DateTime fechaFinal)
        {
            var lista = new List<EReportes>();

            using (var cn = GetConnection())
            {
                cn.Open();
                using (var cmd = new SqlCommand(@"SELECT v.placa, tv.Descripcion, e.fecha_hora_entrada, s.fecha_hora_salida,
                    t.descripcion, c.nombre + ' ' + c.apellido, s.total_pagar FROM Vehiculo v
                    INNER JOIN TiposVehiculo tv ON v.Codigo = tv.Codigo
                    INNER JOIN Entrada e ON v.id_vehiculo = e.id_vehiculo
                    INNER JOIN Salida s ON e.id_entrada = s.id_entrada
                    INNER JOIN Tarifa t ON s.id_tarifa = t.id_tarifa
                    LEFT JOIN Cliente c ON v.id_numero = c.id_numero
                    WHERE e.fecha_hora_entrada BETWEEN @FechaInicial AND @FechaFinal
                    ORDER BY v.placa, e.fecha_hora_entrada;", cn))
                {
                    cmd.Parameters.AddWithValue("@FechaInicial", fechaInicial);
                    cmd.Parameters.AddWithValue("@FechaFinal", fechaFinal);

                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            lista.Add(new EReportes
                            {
                                Vehiculo = r.GetString(0),
                                TipoVehiculo = r.GetString(1),
                                Entrada = r.GetDateTime(2),
                                Salida = r.GetDateTime(3),
                                Tarifa = r.GetString(4),
                                Cliente = r.IsDBNull(5) ? "" : r.GetString(5),
                                TotalPagar = r.GetDecimal(6)
                            });

                        }
                    }
                }
            }
            return lista;
        }


    }
}
