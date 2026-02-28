using Infraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParking.Negocio
{
    public class NotificacionService
    {
        private readonly EmailClient _emailClient;

        public NotificacionService(EmailClient emailClient)
        {
            _emailClient = emailClient;
        }

        public async Task NotificarAsync(string destinatario)
        {
            string asunto = "Prueba de conexión";
            string cuerpo = "Este es un correo de prueba enviado desde el sistema de parqueos.";
            await _emailClient.EnviarCorreoAsync(destinatario, asunto, cuerpo);
        }

    }
}
