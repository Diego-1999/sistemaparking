using SistemaParking.Dato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParking.Negocio
{
    public class NUsuario
    {
        //Instancia con la Clase DUsuario
        private DUsuario dUsuario = new DUsuario();

        public bool RegistrarUsuario(string tipoid, string nombre, string apellido, string telefono,
            string cedula,
            string correo,
            string usuario,
            string contrasena,
            string rol)
        {
            if (string.IsNullOrEmpty(cedula) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(correo))
                return false;

            return dUsuario.RegistrarUsuario(
                tipoid,
                nombre,
                apellido,
                telefono,
                cedula,
                correo,
                usuario,
                contrasena,
                rol
            );
        }
    }
}
