using SistemaParking.Entidad;
using System;
using System.Collections.Generic;
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
            _smtpClient = new SmtpClient(settings.Host, settings.Port)
            {
                Credentials = new NetworkCredential(settings.User, settings.Password),
                EnableSsl = true // Seguridad con TLS/SSL
            };

            _from = settings.From;
        }

        public async Task EnviarCorreoAsync(string destinatario, string asunto, string cuerpo)
        {
            using (var mensaje = new MailMessage(_from, destinatario, asunto, cuerpo))
            {
                await _smtpClient.SendMailAsync(mensaje);
            }

        }





        //private readonly SmtpClient _smtpClient;

        //public EmailClient(string host, int port, string user, string password)
        //{
        //    _smtpClient = new SmtpClient(host, port)
        //    {
        //        Credentials = new NetworkCredential(user, password),
        //        EnableSsl = true // Seguridad con TLS/SSL
        //    };
        //}

        //public async Task EnviarCorreoAsync(string destinatario, string asunto, string cuerpo)
        //{
        //    var mensaje = new MailMessage("tu_correo@dominio.com", destinatario, asunto, cuerpo);
        //    await _smtpClient.SendMailAsync(mensaje);
        //}

    }
}
