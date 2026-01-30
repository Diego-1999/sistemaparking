using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParking.Entidad
{
    public class EReportes
    {
        public string Vehiculo { get; set; }
        public string TipoVehiculo { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Salida { get; set; }
        public string Tarifa { get; set; }
        public string Cliente { get; set; }
        public decimal TotalPagar { get; set; }

    }
}
