using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParking.Entidad
{
    public class ESalida
    {
        public int id_salida { get; set; }
        public DateTime fecha_hora_salida { get; set; }
        public decimal total_pagar { get; set; }
        public int id_entrada { get; set; }
        public int id_tarifa { get; set; }
        public string numero_id { get; set; } // colaborador
        public string id_numero { get; set; } // cliente (opcional)

    }
}
