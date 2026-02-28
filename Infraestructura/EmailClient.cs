using SistemaParking.Entidad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura
{
    public class EmailClient
    {
        private readonly SmtpClient _smtpClient;
        private readonly string _from;

        public EmailClient(EmailSettings settings)
        {
            
            _from = settings.From; // ← aquí se guarda el remitente configurado
            _smtpClient = new SmtpClient(settings.Host, settings.Port)
            {

                Credentials = new NetworkCredential(settings.User, settings.Password),
                EnableSsl = true // Seguridad con TLS/SSL
            };

            _from = settings.From;
        }

        public async Task EnviarCorreoAsync(string destinatario, string asunto, string cuerpo, string rutaAdjunto = null)
        {
            using (var mensaje = new MailMessage(_from, destinatario, asunto, cuerpo))
            {
                if (!string.IsNullOrEmpty(rutaAdjunto) && File.Exists(rutaAdjunto))
                {
                    mensaje.Attachments.Add(new Attachment(rutaAdjunto));
                }

                await _smtpClient.SendMailAsync(mensaje);
            }
        }

    }
}
