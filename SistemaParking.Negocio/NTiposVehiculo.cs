using SistemaParking.Dato;
using SistemaParking.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParking.Negocio
{
    public class NTiposVehiculo
    {
        //instancia con la clase DTiposVehiculo de la capa Datos
        DTiposVehiculo dtiposvehiculo = new DTiposVehiculo();
        public List<ETiposVehiculo> ListarTipoVehiculo()
        {
           return dtiposvehiculo.GetTiposVehiculos();
        }
    }
}
