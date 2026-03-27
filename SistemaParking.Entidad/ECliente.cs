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
      
        // Relación un cliente puede tener varios vehículos
        public List<EVehiculo> Vehiculos { get; set; }


        /* Propiedades de solo lectura que devuelven la Marca, Color y TipoVehiculo del primer elemento en la lista Vehiculos. 
         Si la lista está vacía o es nula, se retorna una cadena vacía para evitar errores.*/
        public string Placa => Vehiculos != null && Vehiculos.Count > 0 ? Vehiculos[0].Placa : "";
        public string Marca => Vehiculos != null && Vehiculos.Count > 0 ? Vehiculos[0].Marca : "";
        public string Color => Vehiculos != null && Vehiculos.Count > 0 ? Vehiculos[0].Color : "";
        public string TipoVehiculo => Vehiculos != null && Vehiculos.Count > 0 ? Vehiculos[0].TipoVehiculo : "";
    }
}
