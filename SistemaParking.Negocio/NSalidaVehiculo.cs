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
        //instancias
        DSalidaVehiculo dSalida = new DSalidaVehiculo();
        DTarifa dtarifa = new DTarifa();
        NTarifa nTarifa = new NTarifa();
      

            public ETiqueteSalida GenerarTiqueteSalida(string placa, string numeroIdColaborador)
            {
                // Traer datos de entrada
                var datosEntrada = dSalida.ObtenerInfoSalida(placa);

                // Obtener tarifa desde la base
                var tarifa = dtarifa.ObtenerTarifa(datosEntrada.tarifa.id_tarifa);
                if (tarifa == null)
                    throw new Exception("No existe una tarifa activa para el ID especificado.");

                // Calcular monto
                decimal total = nTarifa.CalcularMonto(
                    datosEntrada.fechaEntrada,
                    DateTime.Now,
                    tarifa
                );

                // Registrar salida en la capa de datos con el monto correcto
                var datos = new DSalidaVehiculo().RegistrarSalida(placa, numeroIdColaborador, total);

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
