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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaParking
{
    public partial class Registrar_Reserva : Form
    {

        NEspaciosParqueo nEspacios = new NEspaciosParqueo();
        NEntradaVehiculo negocio = new NEntradaVehiculo();

        public Registrar_Reserva()
        {
            InitializeComponent();
            tipoVehiculo();
            tipoReserva();
        }

        private void tipoVehiculo()
        {
            cmbtipo.DataSource = new NTiposVehiculo().ListarTipoVehiculo();
            cmbtipo.DisplayMember = "Descripcion";
            cmbtipo.ValueMember = "Codigo";
            cmbtipo.SelectedIndex = -1;
        }

        private void tipoReserva()
        {
            cmbReserva.DataSource = new NReserva().ListarReserva();
            cmbReserva.DisplayMember = "descripcion_reserva";
            cmbReserva.ValueMember = "id_reserva";
            cmbReserva.SelectedIndex = -1;
        }

        private async void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                //variables 
                int espaciosDisponibles = 0;


                if (SesionActual.Usuario == null)
                {
                    MessageBox.Show("Debe iniciar sesión");
                    return;
                }

                string numeroIdColaborador = SesionActual.Usuario.NumeroIdColaborador;
                if (string.IsNullOrWhiteSpace(txtPlaca.Text))
                {
                    MessageBox.Show("Debe ingresar la placa del vehículo", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPlaca.Focus();

                }
                else if (!ValidarPlaca(txtPlaca.Text))
                {
                    MessageBox.Show("Placa inválida", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPlaca.Focus();
                }
                else if (cmbReserva.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione los dias de reserva", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbReserva.Focus();

                }
                else if (cmbtipo.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un tipo de vehículo", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbtipo.Focus();

                }
                else
                {
                    // Validar espacios disponibles
                    string tipoVehiculo = cmbtipo.SelectedValue.ToString();

                    if (tipoVehiculo == "PART")
                    {
                        espaciosDisponibles = nEspacios.ObtenerEspaciosVehiculosDisponibles();
                    }
                    else if (tipoVehiculo == "MOT")
                    {
                        espaciosDisponibles = nEspacios.ObtenerEspaciosMotosDisponibles();
                    }


                    if (espaciosDisponibles <= 0)
                    {
                        MessageBox.Show("El parqueo está lleno. No hay espacios disponibles 🚫");
                        return;
                    }

                    // Generar tiquete
                    var tiquete = negocio.GenerarTiqueteEntrada(
                        txtPlaca.Text,
                        cmbTipoVehiculo.Text,
                        numeroIdColaborador
                    );

                    if (tiquete == null)
                    {
                        MessageBox.Show("No se pudo registrar el vehículo ❌");
                        return;
                    }

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

                    // Configurar y delegar envío de correo
                    var config = new ConfigurationBuilder()
                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .Build();

                    var emailSettings = config.GetSection("EmailSettings").Get<EmailSettings>();
                    var emailClient = new EmailClient(emailSettings);
                    var notificacionService = new NotificacionService(emailClient);


                    await notificacionService.NotificarConTiqueteAsync(tiquete, ruta);

                    // Limpiar campos
                    txtPlaca.Clear();
                    cmbtipo.SelectedIndex = -1;
                    cmbReserva.SelectedIndex = -1;
                    txtPlaca.Focus();

                    bool ok = true;
                    if (ok)
                    {
                        MessageBox.Show("Vehículo registrado correctamente ✅");

                        //Refrescar los labels de espacios
                        var menu = Application.OpenForms.OfType<Menu>().FirstOrDefault();
                        if (menu != null)
                            menu.ActualizarLabels();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        // Validacione 
        public static bool ValidarPlaca(string strNumber)
        {
            Regex regex = new Regex(@"(^[A-Z]{3}[0-9]{3}$)|(^[0-9]{6}$)");
            Match match = regex.Match(strNumber);

            if (match.Success)
                return true;
            else
                return false;
        }

        private void btnSalidaReserva_Click(object sender, EventArgs e)
        {
            // Instancia del formulario que necesito llamar para mostrar en el panel
            Registrar_Salida_Reserva registrar_Salida_ = new Registrar_Salida_Reserva();

            // se llama al método del formulario principal
            Menu menu = (Menu)this.ParentForm;
            menu.AbrirFormPanel(registrar_Salida_);

        }
    }
}
