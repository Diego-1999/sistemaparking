using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParking.Entidad
{
    public class EUsuario
    {
        public string numero_id { get; set; }
        public string tipo_id { get; set; }
        public string TipoIdentificacion { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string usuario { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public int IdRol { get; set; }
        public string Rol { get; set; }
        public string Contrasena { get; set; } // hash en Base64
        public string Salt { get; set; }       // salt en Base64
        public int Iteraciones { get; set; }   // número de iteraciones
    }
}
