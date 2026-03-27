using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParking.Entidad
{
    public class ERegistroVehiculo
    {
        public int IdEntrada { get; set; }      
        public string Placa { get; set; }       
        public string TipoVehiculo { get; set; }
        public DateTime FechaHoraEntrada { get; set; }
    }
}
