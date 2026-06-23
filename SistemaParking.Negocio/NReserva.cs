using Infraestructura;
using SistemaParking.Dato;
using SistemaParking.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParking.Negocio
{
    public class NReserva
    {
        DReserva dreserva = new DReserva();
        DCliente dcliente = new DCliente();
        DEntradaVehiculo dVehiculo = new DEntradaVehiculo();

        private static int contador = 0;
        public List<EReserva> ListarReserva()
        {
            return dreserva.GetReserva();
        }
        
        public bool RegistrarTarifaReserva(string descripcion, int monto, string tiempoReserva, string TipoVehiculo)
        {
            return dreserva.RegistrarTarifaReserva(
                descripcion,
                monto,
                tiempoReserva,
                TipoVehiculo);
        }


        public (bool registrado, string idCliente) RegistroVehiculo(string placa, int reserva, string nombreTipoVehiculo, string numeroIdColaborador)
        {
            return dreserva.RegistrarReserva(placa.Trim(),  reserva, nombreTipoVehiculo, numeroIdColaborador);
        }

        //Metodo obtiene el correo del cliente
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
                IdCliente = resultado.idCliente
            };
        }

        public List<ERegistroVehiculo> MostrarVehiculosEnParqueo()
        {
            return dVehiculo.ObtenerVehiculosEnParqueo();
        }


        private DEntradaVehiculo eliminar = new DEntradaVehiculo();

        public bool EliminarEntrada(int idEntrada)
        {
            return eliminar.EliminarEntrada(idEntrada);
        }

        public int ContarVehiculosEnParqueo()
        {
            return dVehiculo.ContarVehiculosEnParqueo();
        }

        public ETiqueteSalida RegistrarSalida(string placa, string numeroIdColaborador)
        {
            // 1. Obtener entrada activa
            var datosEntrada = dreserva.ObtenerInfoReserva(placa);

            // 2. Obtener tarifa asociada
            var tarifa = dreserva.ObtenerTarifaReserva(datosEntrada.tarifa.id_tarifa);
            if (tarifa == null)
                throw new Exception("No existe una tarifa activa para el ID especificado.");

            // 3. Calcular monto SOLO por días de reserva
            int diasReservados = tarifa.id_reserva; // el catálogo define los días (1,2,3…)
            decimal total = diasReservados * tarifa.monto_por_hora; // monto_por_hora funciona como monto_por_día

            // 4. Registrar salida en BD
            var salida = dreserva.RegistrarSalidaReserva(placa, numeroIdColaborador, total);

            // 5. Generar tiquete con días reservados explícitos
            return new ETiqueteSalida
            {
                PlacaVehiculo = placa,
                FechaEntrada = salida.fechaEntrada,
                FechaSalida = salida.fechaSalida,
                TiempoTotal = salida.fechaSalida - salida.fechaEntrada,
                MontoCobrado = salida.total,
                IdCliente = salida.idCliente,
            };
        }




    }
}
