using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParking.Entidad
{
    public class EEntrada
    {
        public int id_entrada { get; set; }
        public DateTime fecha_hora_entrada { get; set; }
        public int id_vehiculo { get; set; }
        public int id_parqueo { get; set; }
        public string numero_id { get; set; } //tabla Colaborador
        public string id_numero { get; set; } // tabla Cliente

    }
}
