using SistemaParking.Dato;
using SistemaParking.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParking.Negocio
{
    public class NCliente
    {
        // Instancia con la Clase DCLiente
        private DCliente dCliente = new DCliente();

        // Método expuesto a la capa de presentación
        public bool RegistrarCliente(string tipoid, string cedula, string nombre, string apellidos, string telefono, string correo, string placa,
            string nombreTipoVehiculo, string marca, string color)
        {

            if (string.IsNullOrEmpty(cedula) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(correo))
                return false;

            return dCliente.RegistrarCliente(
                tipoid,
                cedula,
                nombre,
                apellidos,
                telefono,
                correo,
                placa,
                nombreTipoVehiculo,
                marca,
                color
            );
        }

        //Metodo mostrar clientes
        public List<ECliente> MostrarClientes()
        {
            return dCliente.MostrarClientes();
        }

        //Metodo Buscar cliente en el data
        public List<ECliente> BuscarClientes(string busqueda)
        {
            return dCliente.BuscarClientes(busqueda);
        }

        //Metodo para Buscar en el Padron Electoral
        public ECliente BuscarPadronElectoral(string cedula)
        {
            return dCliente.BuscarPadronElectoral(cedula);
        }

        //Metodo que obtiene el correo del cliente
        public string ObtenerCorreoPorId(string idCliente)
        {
            return dCliente.ObtenerCorreoPorId(idCliente);
        }

        //Metodo editar cliete
        public bool EditarClienteYVehiculo(ECliente cliente)
        {
            return dCliente.EditarClienteYVehiculo(cliente);
        }

        //Metodo Eliminar Cliente
        public bool EliminarCliente(ECliente cliente)
        {
            // Se Elimina un cliente y sus dependencias usando la entidad completa.

            if (cliente == null || string.IsNullOrWhiteSpace(cliente.Cedula))
                throw new ArgumentException("El cliente o su cédula no pueden ser nulos.");

            try
            {
                // Delegar a la capa de datos usando la cédula como clave
                return dCliente.EliminarCliente(cliente.Cedula);
            }
            catch (Exception ex)
            {
                // Aquí puedes registrar el error en bitácora o lanzar una excepción custom
                Console.WriteLine("Error en capa negocio al eliminar cliente: " + ex.Message);
                return false;
            }
        }

    }
}