using SistemaParking.Dato;
using SistemaParking.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParking.Negocio
{
    public class NTarifa
    {
        DTarifa dtarifa = new DTarifa();
        public decimal CalcularMonto(DateTime fechaEntrada, DateTime fechaSalida, ETarifa tarifa)
        {
            //la salida no puede ser antes que la entrada
            if (fechaSalida < fechaEntrada)
                throw new ArgumentException("La fecha de salida no puede ser anterior a la fecha de entrada.");

            TimeSpan tiempo = fechaSalida - fechaEntrada; //Se obtener la duración exacta entre entrada y salida.


            int horasCompletas = (int)Math.Floor(tiempo.TotalHours);//tiempo.TotalHours devuelve el total de horas transcurridas incluyendo decimales.
                                                                    //Math.Floor redondea hacia abajo al entero más cercano.

            int minutosTotales = (int)(tiempo.TotalMinutes - (horasCompletas * 60));// tiempo.TotalMinutes devuelve el total de minutos transcurridos.
                                                                                    //horasCompletas * 60 convierte las horas completas a minutos.

            decimal total = horasCompletas * tarifa.monto_por_hora; //Multiplica las horas completas por la tarifa por hora 

            // Cobro por fracciones
            if (tarifa.fraccion_minutos.HasValue && tarifa.monto_fraccion.HasValue && minutosTotales > 0)
            {
                int fracciones = (int)Math.Ceiling( //Math.Ceiling para redondear hacia arriba las fracciones

                    (double)minutosTotales / tarifa.fraccion_minutos.Value);

                total += fracciones * tarifa.monto_fraccion.Value;
            }
            // Si no hay fracción configurada, se cobra una hora adicional
            else if (minutosTotales > 0)
            {
                total += tarifa.monto_por_hora;
            }

            // Cobro mínimo: al menos una hora
            return Math.Max(total, tarifa.monto_por_hora);
        }

        public bool RegistroTarifa(string descripcion, decimal montoHora, int fraccionMinuto, decimal montoFraccion, string nombreTipoVehiculo)
        {
            // Reglas de negocio
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripcion es obligatoria");

            // Delegar a datos
            return dtarifa.RegistrarTarifa(
                descripcion.Trim(),
                montoHora,
                fraccionMinuto,
                montoFraccion,
                nombreTipoVehiculo
            );
        }
    }
}
