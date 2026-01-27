using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParking.Entidad
{
    public class ETarifa
    {
        public int id_tarifa { get; set; }
        public string descripcion { get; set; }
        public decimal monto_por_hora { get; set; }
        public int? fraccion_minutos { get; set; }
        public decimal? monto_fraccion { get; set; }
        public bool Estado { get; set; } = true;
        public string Codigo { get; set; } // Tipo Vehiculo
    }
}
