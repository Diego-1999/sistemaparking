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

        private DEspaciosParqueo datos = new DEspaciosParqueo();
        public int ObtenerEspaciosVehiculosDisponibles()
        {
            // Todos los códigos que ocupan espacios de carro
            string[] codigosVehiculo = { "PART", "CL" };

            int ocupados = 0;
            foreach (var codigo in codigosVehiculo)
            {
                ocupados += datos.ObtenerOcupadosPorCodigo(codigo);
            }

            return 52 - ocupados;
        }

        public int ObtenerEspaciosMotosDisponibles()
        {
            return 5 - datos.ObtenerOcupadosPorCodigo("MOT");
        }

    }
}
