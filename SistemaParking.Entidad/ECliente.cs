using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParking.Entidad
{
    public class ECliente
    {
        public string Cedula { get; set; }      // id_numero
        public string TipoId { get; set; }      // tipo_id
        public string Nombre { get; set; }      // nombre
        public string Apellido { get; set; }    // apellido
        public string Telefono { get; set; }    // viene de ContactoCliente
        public string Correo { get; set; }      // viene de ContactoCliente

        // Relación: un cliente puede tener varios vehículos
        public List<EVehiculo> Vehiculos { get; set; }
    }
}
