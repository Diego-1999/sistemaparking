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
    public partial class Salida_Vehiculo : Form
    {
        public Salida_Vehiculo()
        {
            InitializeComponent();
        }

        private void Salida_Vehiculo_Load(object sender, EventArgs e)
        {
            txtPlaca.Focus();
        }

        private  void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPlaca.Clear();
            txtPlaca.Focus();
        }

        private async void btnRegistrarSalida_Click(object sender, EventArgs e)
        {
            try
            {
                NSalidaVehiculo negocio = new NSalidaVehiculo();
                // Procesa la salida y calcula el total
                ETiqueteSalida tiquetesalida = negocio.GenerarTiqueteSalida(
                    txtPlaca.Text,
                    SesionActual.Usuario.NumeroIdColaborador
                );

                if (tiquetesalida == null)
                {
                    MessageBox.Show("No se pudo registrar la salida del vehículo");
                    return;
                }

                // Generar PDF
                string ruta = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    "TiqueteSalida.pdf"
                );

                PdfHelper.GenerarTiqueteSalidaPDF(tiquetesalida, ruta);

                // Abrir PDF automáticamente
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = ruta,
                    UseShellExecute = true
                });

                // Refrescar labels del Menu
                var menu = Application.OpenForms.OfType<Menu>().FirstOrDefault();
                if (menu != null)
                    menu.ActualizarLabels();

                // 🔑 Enviar correo con el tiquete de salida
                var config = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                var emailSettings = config.GetSection("EmailSettings").Get<EmailSettings>();
                var emailClient = new EmailClient(emailSettings);
                var notificacionService = new NotificacionService(emailClient);

                await notificacionService.NotificarConTiqueteSalidaAsync(tiquetesalida, ruta);

                // Limpiar campos
                txtPlaca.Clear();
                txtPlaca.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




            //try
            //{
            //    NSalidaVehiculo negocio = new NSalidaVehiculo();
            //    // Procesa la salida y calcula el total
            //    ETiqueteSalida tiquetesalida = negocio.GenerarTiqueteSalida(
            //        txtPlaca.Text,
            //        SesionActual.Usuario.NumeroIdColaborador
            //    );

            //    // Generar PDF
            //    string ruta = Path.Combine(
            //        Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            //        "TiqueteSalida.pdf"
            //    );

            //    PdfHelper.GenerarTiqueteSalidaPDF(tiquetesalida, ruta);

            //    // Abrir PDF automáticamente
            //    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
            //    {
            //        FileName = ruta,
            //        UseShellExecute = true
            //    });

            //    // Refrescar labels del Menu
            //    var menu = Application.OpenForms.OfType<Menu>().FirstOrDefault();
            //    if (menu != null)
            //        menu.ActualizarLabels();

            //    txtPlaca.Clear();
            //    txtPlaca.Focus();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}


        }

    }

}

