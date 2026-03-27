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

        //Constructor donde se establece    cómo y desde dónde se enviará el correo 
        public EmailClient(EmailSettings settings)
        {       
            _from = settings.From; // se guarda el remitente configurado
            _smtpClient = new SmtpClient(settings.Host, settings.Port)
            {
                Credentials = new NetworkCredential(settings.User, settings.Password), //credeciales del remitente
                EnableSsl = true // Seguridad al correo con TLS/SSL
            };
            _from = settings.From; //se guarda desde que correo se envian los correos
        }

        //metodo donde se arma el correo
        public async Task EnviarCorreoAsync(string destinatario, string asunto, string cuerpo, string rutaAdjunto = null)
        {
            using (var mensaje = new MailMessage(_from, destinatario, asunto, cuerpo)) // en el correo va el remitente, destinatario el asunto y cuerpo   
            {
                if (!string.IsNullOrEmpty(rutaAdjunto) && File.Exists(rutaAdjunto))
                {
                    mensaje.Attachments.Add(new Attachment(rutaAdjunto));
                }

                await _smtpClient.SendMailAsync(mensaje);// se usa SmtpClient para enviar el correo
            }
        }

    }
}
