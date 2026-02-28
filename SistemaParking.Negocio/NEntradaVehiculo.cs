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
        DCliente dcliente = new DCliente();

        //variable
        private static int contador = 0;  // contador en memoria

        public (bool registrado, string idCliente) RegistroVehiculo(string placa, string nombreTipoVehiculo, string numeroIdColaborador)
        {
            return dVehiculo.RegistrarVehiculo(placa.Trim(), nombreTipoVehiculo, numeroIdColaborador);
        }

        public string ObtenerCorreoCliente(string placa)
        {
            string idCliente = dVehiculo.ObtenerIdClientePorPlaca(placa);
            if (!string.IsNullOrEmpty(idCliente))
            {
                return dcliente.ObtenerCorreoPorId(idCliente);
            }
            return null;
        }



        // Método genera el tiquete si el registro fue exitoso
        public ETiqueteEntrada GenerarTiqueteEntrada(string placa, string nombreTipoVehiculo, string numeroIdColaborador)
        {
            var resultado = dVehiculo.RegistrarVehiculo(placa.Trim(), nombreTipoVehiculo, numeroIdColaborador);

            if (!resultado.registrado)
                return null;

            contador++;

            return new ETiqueteEntrada
            {
                Codigo = Guid.NewGuid(),
                Tiquete = contador,
                PlacaVehiculo = placa.Trim(),
                FechaEmision = DateTime.Now,
                tipovehiculo = nombreTipoVehiculo,
                IdCliente = resultado.idCliente // este campo lo puedes agregar a ETiqueteEntrada
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
