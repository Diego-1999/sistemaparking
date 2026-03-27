using SistemaParking.Dato;
using SistemaParking.Datos;
using SistemaParking.Entidad;
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
        //Instacia con la Clase DCliente
        private DCliente dCliente = new DCliente();

        public bool RegistrarUsuario(string tipoid, string cedula, string nombre, string apellido,
                         string telefono, string correo, string usuario,
                         string contrasena, string rol)
        {
            if (string.IsNullOrEmpty(cedula) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(correo))
                return false;

            // Generar salt
            byte[] salt = GenerateSalt();
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

        public List<EUsuario> MostrarUsuarios()
        {
            return dUsuario.MostrarUsuarios();
        }

        public List<EUsuario> BuscarUsuarios(string criterio)
        {
            return dUsuario.BuscarUsuarios(criterio);
        }

        public bool EliminarUsuario(string cedula)
        {
            return dUsuario.EliminarUsuario(cedula);
        }

        public ECliente BuscarPadronElectoral(string cedula)
        {
            return dCliente.BuscarPadronElectoral(cedula);
        }

        public bool EditarUsuario(EUsuario usuario)
        {
            // Generar nuevo salt y hash
            byte[] salt = GenerateSalt();
            int iteraciones = 150000;
            string hashContrasena = HashPassword(usuario.Contrasena, salt, iteraciones);

            usuario.Contrasena = hashContrasena;
            usuario.Salt = Convert.ToBase64String(salt);
            usuario.Iteraciones = iteraciones;

            return dUsuario.ActualizarUsuario(usuario);
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
                return Convert.ToBase64String(pbkdf2.GetBytes(32)); 
            }
        }
    }
}

