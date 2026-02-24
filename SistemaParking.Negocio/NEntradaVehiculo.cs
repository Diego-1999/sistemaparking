using SistemaParking.Dato;
using SistemaParking.Entidad;
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

        //variable
        private static int contador = 0;  // contador en memoria


        // Método actual: mantiene compatibilidad con tu presentación
        public bool RegistroVehiculo(string placa, string nombreTipoVehiculo, string numeroIdColaborador)
        {
            return dVehiculo.RegistrarVehiculo(
                placa.Trim(),
                nombreTipoVehiculo,
                numeroIdColaborador
            );
        }

        // Método genera el tiquete si el registro fue exitoso
        public ETiqueteEntrada GenerarTiqueteEntrada(string placa, string nombreTipoVehiculo, string numeroIdColaborador)
        {
            bool registrado = RegistroVehiculo(placa, nombreTipoVehiculo, numeroIdColaborador);

            if (!registrado)
                return null;

            contador++; // aumentar el conteo

            return new ETiqueteEntrada
            {
                Codigo = Guid.NewGuid(),
                Tiquete = contador,
                PlacaVehiculo = placa.Trim(),
                FechaEmision = DateTime.Now,
                tipovehiculo = nombreTipoVehiculo

            };
        }

        public bool RegistrarSegundoVehiculo(string placa, string nombreTipoVehiculo, string numeroIdCliente, string marca, string color)
        {
            if (string.IsNullOrWhiteSpace(placa))
                throw new ArgumentException("La placa es obligatoria");

            if (string.IsNullOrWhiteSpace(numeroIdCliente))
                throw new ArgumentException("Cliente no válido");

            return dVehiculo.RegistrarSegundoVehiculo(
                placa.Trim(),
                nombreTipoVehiculo,
                numeroIdCliente,
                marca,
                color
            );
        }

    }
}
