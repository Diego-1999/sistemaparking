using SistemaParking.Dato;
using SistemaParking.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParking.Negocio
{
    public class NSalidaVehiculo
    {
        DSalidaVehiculo dSalida = new DSalidaVehiculo();
        DTarifa dtarifa = new DTarifa();
        NTarifa nTarifa = new NTarifa();

        //variable
        private static int contador = 0;  // contador en memoria

        public decimal RegistrarSalida(string placa, string numeroIdColaborador)
        {
            //Obtener datos necesarios
            var datos = dSalida.ObtenerInfoSalida(placa); // se consulta la DSalida para traer la información de la entrada del vehículo

          
            //si no existe tarifa activa
            var tarifa = dtarifa.ObtenerTarifa(datos.tarifa.id_tarifa);
            if (tarifa == null)
                throw new Exception("No existe una tarifa activa para el ID especificado.");

            //Calcular
            decimal total = nTarifa.CalcularMonto(
                datos.fechaEntrada,
                DateTime.Now,
                datos.tarifa
            );
            //Registrar salida
            dSalida.RegistrarSalida( 
                placa,
                numeroIdColaborador,  
                total
            );

            return total;
        }

        public ETiqueteSalida GenerarTiqueteSalida(string placa, string numeroIdColaborador)
        {
            var datos = new DSalidaVehiculo().RegistrarSalida(placa, numeroIdColaborador, 0); // el total lo calculás antes

            if (!datos.registrado) return null;

            return new ETiqueteSalida
            {
                Codigo = Guid.NewGuid(),
                Tiquete = new Random().Next(1000, 9999), 
                PlacaVehiculo = placa,
                FechaEntrada = datos.fechaEntrada,
                FechaSalida = datos.fechaSalida,
                TiempoTotal = datos.fechaSalida - datos.fechaEntrada,
                MontoCobrado = datos.total,
                IdCliente = datos.idCliente 
            };
        }
      
    }
}
