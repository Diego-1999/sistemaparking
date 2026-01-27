using SistemaParking.Datos;
using SistemaParking.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParking.Negocio
{
    public class NLogin
    {
        //instancia con la clase DUsuario de la capa Datos
        DLogin dlogin = new DLogin();


        public UsuarioSesion LoginUser(string user, string pass)
        {
            DLogin dlogin = new DLogin();
            return dlogin.Login(user, pass);
        }

    }
}
