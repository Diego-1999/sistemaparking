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
        public bool RegistrarCliente(string tipoid,string cedula,string nombre,string apellidos,string telefono,string correo,string placa,
            string nombreTipoVehiculo,string marca,string color)
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
        public List<ECliente> MostrarClientes()
        {
            return dCliente.MostrarClientes();
        }

        public List<ECliente> BuscarClientes(string busqueda)
        {
            return dCliente.BuscarClientes(busqueda);
        }

        //Metodo para Buscar en el Padron Electoral
        public ECliente BuscarPadronElectoral(string cedula)
        {
            return dCliente.BuscarPadronElectoral(cedula);
        }
    }
}
