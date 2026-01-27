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

namespace SistemaParking
{
    public partial class Registro_Cliente : Form
    {
        public Registro_Cliente()
        {
            InitializeComponent();
            this.CargarComboTipoVehiculo();
            this.CargarComboMarca();
            this.CargarComboColor();
            this.CargarComboTipoId();
            
        }

        private void Registro_Cliente_Load(object sender, EventArgs e)
        {
            txtNombre.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCedula.Clear();
            txtNombre.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtPlaca.Clear();
            txtNombre.Focus();
            cmbTipoIden.SelectedIndex = -1;
            cmbTipoVehiculo.SelectedIndex = -1;
            cmbMarca.SelectedIndex = -1;
            cmbColor.SelectedIndex = -1;
            txtNombre.Focus();
        }


        //Cargar ComboBox Tipo Vehiculo
        private void CargarComboTipoVehiculo()
        {
            cmbTipoVehiculo.DataSource = new NTiposVehiculo().ListarTipoVehiculo();
            cmbTipoVehiculo.DisplayMember = "Descripcion";
            cmbTipoVehiculo.ValueMember = "Codigo";
            cmbTipoVehiculo.SelectedIndex = -1; //Sin selección inicial
        }

        //Cargar ComboBox Marca
        private void CargarComboMarca()
        {
            cmbMarca.DataSource = new NMarca().ListarMarca();
            cmbMarca.DisplayMember = "nombre_marca";
            cmbMarca.ValueMember = "id_marca";
            cmbMarca.SelectedIndex = -1; //Sin selección inicial
        }

        //Cargar ComboBox Color
        private void CargarComboColor()
        {
            cmbColor.DataSource = new NColor().ListarColor();
            cmbColor.DisplayMember = "nombre_color";
            cmbColor.ValueMember = "id_color";
            cmbColor.SelectedIndex = -1; //Sin selección inicial
        }

        //Cargar ComboBox Tipo id
        private void CargarComboTipoId()
        {
            cmbTipoIden.DataSource = new NTipoID().ListarTipoId();
            cmbTipoIden.DisplayMember = "tipo_id";
            cmbTipoIden.ValueMember = "descripcion";
            cmbTipoIden.SelectedIndex = -1; //Sin selección inicial
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            NCliente negocioCliente = new NCliente();

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Necesita ingresar Nombre", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtCedula.Text))
            {
                MessageBox.Show("Necesita ingresar cedula", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Correo Electronico ", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Llamar al método de negocio con los datos del formulario
            bool resultado = negocioCliente.RegistrarCliente(
                cmbTipoIden.Text,
                txtCedula.Text,
                txtNombre.Text,
                txtApellidos.Text,
                txtTelefono.Text,
                txtEmail.Text,
                txtPlaca.Text,
                cmbTipoVehiculo.Text,
                cmbMarca.Text,
                cmbColor.Text             
            );

            // Mostrar resultado al usuario
            if (resultado)
            {
                MessageBox.Show("Cliente registrado correctamente ✅",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Error al registrar cliente ❌",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
