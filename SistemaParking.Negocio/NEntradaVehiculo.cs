using SistemaParking.Dato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParking.Negocio
{
    public class NEntradaVehiculo
    {

        //instancia con DVehiculo
        DEntradaVehiculo dVehiculo = new DEntradaVehiculo();

        public bool RegistroVehiculo(string placa, string nombreTipoVehiculo, string numeroIdColaborador)
        {
            // Reglas de negocio
            if (string.IsNullOrWhiteSpace(placa))
                throw new ArgumentException("La placa es obligatoria");

            if (string.IsNullOrWhiteSpace(numeroIdColaborador))
                throw new ArgumentException("Colaborador no válido");

            // Delegar a datos
            return dVehiculo.RegistrarVehiculo(
                placa.Trim(),
                nombreTipoVehiculo,
                numeroIdColaborador
            );
        }

    }
}
