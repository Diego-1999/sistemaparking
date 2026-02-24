using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParking.Entidad
{
    public class ETiqueteEntrada
    {
            public Guid Codigo { get; set; } = Guid.NewGuid();
            public int Tiquete { get; set; }
            public DateTime FechaEmision { get; set; } = DateTime.Now;
            public string PlacaVehiculo { get; set; }
            public string tipovehiculo { get; set; }
    }
}
