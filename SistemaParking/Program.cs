using Infraestructura;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration.Binder;
using SistemaParking.Entidad;
using SistemaParking.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaParking
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {

            var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            var emailSettings = config.GetSection("EmailSettings").Get<EmailSettings>();

            var services = new ServiceCollection();
            services.AddSingleton(new EmailClient(emailSettings));
            services.AddTransient<NotificacionService>();

            var provider = services.BuildServiceProvider();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Arranca en Login
            Application.Run(new Login());










            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Login());


            // Cargar configuración desde appsettings.json
            //var config = new ConfigurationBuilder()
            //    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //    .Build();

            //var emailSettings = config.GetSection("EmailSettings").Get<EmailSettings>();

            //// Configuración de DI
            //var services = new ServiceCollection();
            //services.AddSingleton(new EmailClient(emailSettings));
            //services.AddTransient<NotificacionService>();

            //var provider = services.BuildServiceProvider();

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            //// Ejemplo: enviar correo antes de abrir el formulario principal
            //var notificacionService = provider.GetRequiredService<NotificacionService>();
            //notificacionService.NotificarAsync("diego18u1999@gmail.com").Wait();

            //Application.Run(new Login());

        }





        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new Login());

        //}



    }
}
