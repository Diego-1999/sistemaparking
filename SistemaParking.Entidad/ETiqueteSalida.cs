using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParking.Entidad
{
    public class ETiqueteSalida
    {
            public Guid Codigo { get; set; } = Guid.NewGuid();
            public int Tiquete { get; set; }          // consecutivo con ContadorHelper
            public DateTime FechaSalida { get; set; } = DateTime.Now;
            public string PlacaVehiculo { get; set; }
            public string TipoVehiculo { get; set; }
            public decimal MontoCobrado { get; set; }
    }
}
