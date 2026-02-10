using SistemaParking.Dato;
using SistemaParking.Datos;
using SistemaParking.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParking.Negocio
{
    public class NLogin
    {
        //instancia con la clase DUsuario de la capa Datos
        DLogin dlogin = new DLogin();

        public UsuarioSesion LoginUser(string usuario, string contrasena)
        {
            var datosUsuario = dlogin.Login(usuario);
            if (datosUsuario == null) return null;

            using (var pbkdf2 = new Rfc2898DeriveBytes(contrasena, datosUsuario.Salt, datosUsuario.Iteraciones, HashAlgorithmName.SHA256))
            {
                byte[] hashIngresado = pbkdf2.GetBytes(32);

                if (hashIngresado.SequenceEqual(datosUsuario.ContrasenaHash))
                {
                    return datosUsuario; // Login correcto
                }
                else
                {
                    return null; // Contraseña incorrecta
                }
            }
        }   
    }
}
