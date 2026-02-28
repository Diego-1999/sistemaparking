using Infraestructura;
using SistemaParking.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParking.Negocio
{
    public class NotificacionService
    {

        private readonly EmailClient _emailClient;
        private readonly NCliente _nCliente;


        public NotificacionService(EmailClient emailClient)
        {
            _emailClient = emailClient;
            _nCliente = new NCliente(); // se respeta la arquitectura

        }

        public async Task NotificarConTiqueteAsync(ETiqueteEntrada tiquete, string rutaAdjunto)
        {
            string correoCliente = null;

            if (!string.IsNullOrEmpty(tiquete.IdCliente))
            {
                correoCliente = _nCliente.ObtenerCorreoPorId(tiquete.IdCliente);
            }

            string destinatario = correoCliente ?? "correo_generico@dominio.com";
            string asunto = "Tiquete de Parqueo";
            string cuerpo = $"Estimado {(correoCliente != null ? "Cliente" : "Visitante")},\n\n" +
                            $"Su tiquete de parqueo ha sido generado.\n\n" +
                            $"📌 *Placa:* {tiquete.PlacaVehiculo}\n" +
                            $"📅 *Fecha:* {tiquete.FechaEmision}\n" +
                            $"🚗 *Tipo:* {tiquete.tipovehiculo}\n" +
                            $"🎫 *Código:* {tiquete.Tiquete}";

            await _emailClient.EnviarCorreoAsync(destinatario, asunto, cuerpo, rutaAdjunto);
        }
    }
}
