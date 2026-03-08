using SistemaParking.Dato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParking.Negocio
{
    public class NEspaciosParqueo
    {
        //instancias
        DEspaciosParqueo despacio = new DEspaciosParqueo();


        public bool RegistroEspacio(int numeroEspacio, string tipoEspacio)
        {
            // Reglas de negocio
            if (string.IsNullOrWhiteSpace(tipoEspacio))
                throw new ArgumentException("El Tipo de espacio es obligatoria");

            // Delegar a datos
            return despacio.EstablecerEspacios(
                numeroEspacio,
                tipoEspacio.Trim()
            );
        }

        public int ObtenerEspaciosVehiculosDisponibles()
        {
            int totalEspacios =
                despacio.ObtenerTotalEspacios("PART");

            int ocupados = despacio.ObtenerOcupadosPorCodigo("PART");

            return totalEspacios- ocupados;
        }


        public int ObtenerEspaciosMotosDisponibles()
        {
            // Total de espacios para motos
            int totalEspacios = despacio.ObtenerTotalEspacios("MOT");

            // Ocupados actualmente  entradas/salidas
            int ocupados = despacio.ObtenerOcupadosPorCodigo("MOT");

            // Disponibles = total - ocupados
            return totalEspacios - ocupados;
        }

    }
}
