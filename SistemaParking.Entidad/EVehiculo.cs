using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParking.Entidad
{
    public class EVehiculo
    {
        public int id_vehiculo { get; set; }
        public string placa { get; set; }
        public string id_numero { get; set; }
        public string Codigo { get; set; }
        public int id_marca { get; set; }
        public int id_modelo { get; set; }
        public int id_color { get; set; }
    }
}
