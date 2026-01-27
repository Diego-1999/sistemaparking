using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParking.Entidad
{
    public class UsuarioSesion
    {  
            public int IdUsuario { get; set; }
            public string Usuario { get; set; }
            public int IdRol { get; set; }
            public string NombreRol { get; set; }
            public string NumeroIdColaborador { get; set; }
       
    }
}
