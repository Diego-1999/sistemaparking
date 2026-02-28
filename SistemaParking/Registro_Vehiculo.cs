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
using Infraestructura;


namespace SistemaParking
{
    public partial class Registro_Vehiculo : Form
    {
        public Registro_Vehiculo()
        {
            InitializeComponent();
        }

        //Evento principal del forms Registro_Vehiculo
        private void Registro_Vehiculo_Load(object sender, EventArgs e)
        {
            txtPlaca.Focus();
            this.CargarComboTipoVehiculo();
        }

        private void btnRegistrarCliente_Click(object sender, EventArgs e)
        {
            // Instancia del formulario que necesito llamar para mostrar en el panel
            Registro_Cliente frmCliente = new Registro_Cliente();

            // se llama al método del formulario principal
            Menu menu = (Menu)this.ParentForm;
            menu.AbrirFormPanel(frmCliente);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPlaca.Clear();
            cmbTipoVehiculo.SelectedIndex = -1;
            txtPlaca.Focus();
        }

        //Cargar ComboBox
        private void CargarComboTipoVehiculo()
        { 
                cmbTipoVehiculo.DataSource = new NTiposVehiculo().ListarTipoVehiculo();
                cmbTipoVehiculo.DisplayMember = "Descripcion";
                cmbTipoVehiculo.ValueMember = "Codigo";
                cmbTipoVehiculo.SelectedIndex = -1; //Sin selección inicial
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            if (SesionActual.Usuario == null)
            {
                MessageBox.Show("Debe iniciar sesión");
                return;
            }

            string numeroIdColaborador = SesionActual.Usuario.NumeroIdColaborador;
            NEntradaVehiculo negocio = new NEntradaVehiculo();

            bool ok = negocio.RegistroVehiculo(
                txtPlaca.Text,
                cmbTipoVehiculo.Text,
                numeroIdColaborador
            );

            if (ok)
            {
                var tiquete = new ETiqueteEntrada
                {
                    Tiquete = ContadorHelper.ObtenerSiguienteCodigo(),
                    Codigo = Guid.NewGuid(),
                    PlacaVehiculo = txtPlaca.Text.Trim(),
                    FechaEmision = DateTime.Now,
                    tipovehiculo = cmbTipoVehiculo.Text
                };

                // Generar PDF
                string ruta = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    "TiqueteEntrada.pdf"
                );
                PdfHelper.GenerarTiqueteEntradaPDF(tiquete, ruta);

                // Abrir PDF automáticamente
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = ruta,
                    UseShellExecute = true
                });

                // --- Enviar correo ---
                var notificacionService = provider.GetRequiredService<NotificacionService>();

                // Buscar cliente por placa
                var cliente = negocio.BuscarClientePorPlaca(txtPlaca.Text.Trim());

                string destinatario = cliente?.Email ?? "correo_generico@dominio.com";
                string asunto = "Tiquete de Parqueo";
                string cuerpo = $"Estimado {cliente?.Nombre ?? "Visitante"},\n\n" +
                                $"Su tiquete de parqueo ha sido generado.\n" +
                                $"Placa: {tiquete.PlacaVehiculo}\n" +
                                $"Fecha: {tiquete.FechaEmision}\n" +
                                $"Tipo: {tiquete.tipovehiculo}\n" +
                                $"Código: {tiquete.Tiquete}";

                await notificacionService.NotificarAsync(destinatario, asunto, cuerpo, ruta);
            }




            //if (ok)
            //{
            //    // Generar tiquete en memoria
            //    var tiquete = new ETiqueteEntrada
            //    {
            //        Tiquete = ContadorHelper.ObtenerSiguienteCodigo(),
            //        Codigo = Guid.NewGuid(),
            //        PlacaVehiculo = txtPlaca.Text.Trim(),
            //        FechaEmision = DateTime.Now,
            //        tipovehiculo = cmbTipoVehiculo.Text

            //    };


            //    // Generar PDF
            //    string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "TiqueteEntrada.pdf");
            //    PdfHelper.GenerarTiqueteEntradaPDF(tiquete, ruta);

            //    // Abrir PDF automáticamente para imprimir
            //    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
            //    {
            //        FileName = ruta,
            //        UseShellExecute = true
            //    });
        }
            else
            {
                MessageBox.Show("No se pudo registrar el vehículo");
            }

            txtPlaca.Clear();
            cmbTipoVehiculo.SelectedIndex = -1;
            txtPlaca.Focus();
        }
    }
}
