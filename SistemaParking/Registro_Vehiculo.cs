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
            //Limpiar campos
            txtPlaca.Clear();
            cmbTipoVehiculo.SelectedIndex = -1;
            txtPlaca.Focus();
        }

        
        private void CargarComboTipoVehiculo()
        {
            //Cargar ComboBox
            cmbTipoVehiculo.DataSource = new NTiposVehiculo().ListarTipoVehiculo();
            cmbTipoVehiculo.DisplayMember = "Descripcion";
            cmbTipoVehiculo.ValueMember = "Codigo";
            cmbTipoVehiculo.SelectedIndex = -1; //Sin selección inicial
        }

        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (SesionActual.Usuario == null)
                {
                    MessageBox.Show("Debe iniciar sesión");
                    return;
                }

                string numeroIdColaborador = SesionActual.Usuario.NumeroIdColaborador;
                if (string.IsNullOrWhiteSpace(txtPlaca.Text))
                {
                    MessageBox.Show("Debe ingresar la placa del vehículo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPlaca.Focus();

                }
                else if (cmbTipoVehiculo.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un tipo de vehículo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbTipoVehiculo.Focus();

                }
                else
                {
                    NEntradaVehiculo negocio = new NEntradaVehiculo();

                    // Generar tiquete (ya incluye idCliente si aplica)
                    var tiquete = negocio.GenerarTiqueteEntrada(
                        txtPlaca.Text,
                        cmbTipoVehiculo.Text,
                        numeroIdColaborador
                    );

                    if (tiquete == null)
                    {
                        MessageBox.Show("No se pudo registrar el vehículo");
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
                    cmbTipoVehiculo.SelectedIndex = -1;
                    txtPlaca.Focus();

                    bool ok = true;
                    if (ok)
                    {
                        MessageBox.Show("Vehículo registrado correctamente");

                        //Refrescar los labels de espacios
                        var menu = Application.OpenForms.OfType<Menu>().FirstOrDefault();
                        if (menu != null)
                            menu.ActualizarLabels();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }                       
        }
    }
}
