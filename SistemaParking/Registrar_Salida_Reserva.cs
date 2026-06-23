using Infraestructura;
using Microsoft.Extensions.Configuration;
using SistemaParking.Entidad;
using SistemaParking.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaParking
{
    public partial class Registrar_Salida_Reserva : Form
    {
        public Registrar_Salida_Reserva()
        {
            InitializeComponent();
        }

        private async void btnRegistrarSalidaReserva_Click(object sender, EventArgs e)
        {
            try
            {
                NReserva negocio = new NReserva();
                // Procesa la salida de la reserva y calcula el total
                ETiqueteSalida tiqueteSalida = negocio.RegistrarSalida(
                    txtPlaca.Text,
                    SesionActual.Usuario.NumeroIdColaborador
                );

                if (tiqueteSalida == null)
                {
                    MessageBox.Show("No se pudo registrar la salida de la reserva");
                    return;
                }

                // Generar PDF
                string ruta = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    "TiqueteSalidaReserva.pdf"
                );

                PdfHelper.GenerarTiqueteSalidaPDF(tiqueteSalida, ruta);

                // Abrir PDF automáticamente
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = ruta,
                    UseShellExecute = true
                });

                // Refrescar labels del menú
                var menu = Application.OpenForms.OfType<Menu>().FirstOrDefault();
                if (menu != null)
                    menu.ActualizarLabels();

                // Enviar correo con el tiquete de salida
                var config = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                var emailSettings = config.GetSection("EmailSettings").Get<EmailSettings>();
                var emailClient = new EmailClient(emailSettings);
                var notificacionService = new NotificacionService(emailClient);

                await notificacionService.NotificarConTiqueteSalidaAsync(tiqueteSalida, ruta);

                // Limpiar campos
                txtPlaca.Clear();
                txtPlaca.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
