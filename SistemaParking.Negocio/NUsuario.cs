using SistemaParking.Dato;
using SistemaParking.Datos;
using SistemaParking.Entidad;
using System;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace SistemaParking.Negocio
{
    public class NUsuario
    {
        //Instancia con la Clase DUsuario
        private DUsuario dUsuario = new DUsuario();

        public bool RegistrarUsuario(string tipoid, string nombre, string apellido, string telefono,
            string cedula, string correo, string usuario, string contrasena, string rol)
        {
            if (string.IsNullOrEmpty(cedula) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(correo))
                return false;

            // Generar salt
            byte[] salt = GenerateSalt();

            // Definir número de iteraciones
            int iteraciones = 150000;


            // Derivar contraseña con PBKDF2
            string hashContrasena = HashPassword(contrasena, salt, iteraciones);

            // Pasar hash y salt a la capa de datos
            return dUsuario.RegistrarUsuario(
                tipoid,
                nombre,
                apellido,
                telefono,
                cedula,
                correo,
                usuario,
                hashContrasena,
                Convert.ToBase64String(salt), // almacenar salt como Base64
                iteraciones,
                rol
            );
        }

        private static byte[] GenerateSalt(int size = 16)
        {
            var salt = new byte[size];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        private static string HashPassword(string password, byte[] salt, int iterations = 150000)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
            {
                return Convert.ToBase64String(pbkdf2.GetBytes(32)); // 256 bits
            }
        }
    }
}

