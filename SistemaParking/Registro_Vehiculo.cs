using SistemaParking.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

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

            if (SesionActual.Usuario == null)  //validamos si la sesion esta iniciada
            {
                MessageBox.Show("Debe iniciar sesión");
                return;
            }

            string numeroIdColaborador = SesionActual.Usuario.NumeroIdColaborador; //el usuario que inicia sesion se asigna a una variab;e 

            //instanciamos la capa negocio 
            NEntradaVehiculo negocio = new NEntradaVehiculo();
            bool ok = negocio.RegistroVehiculo(
                txtPlaca.Text,
                cmbTipoVehiculo.Text,     //pasamos los parametros a la capa negocio 
                numeroIdColaborador
            );

            if (ok)
                MessageBox.Show("Vehículo registrado correctamente");
            else
                MessageBox.Show("No se pudo registrar el vehículo");
           
        }
    }
}
