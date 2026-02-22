using SistemaParking.Entidad;
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

        //intancias a capa negocio
        NEntradaVehiculo nEntradaVehiculo = new NEntradaVehiculo();
        NCliente negocioCliente = new NCliente();

        private void Registro_Cliente_Load(object sender, EventArgs e)
        {
            txtNombre.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            mskCedula.Clear();
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
            mskCedula.Focus();
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

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Necesita ingresar nombre", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!mskCedula.MaskCompleted) //se obliga que la mskCedula este completa
            {
                MessageBox.Show("Necesita ingresar la cédula", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Necesita ingresar el correo", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Normalizar la cédula (quitar guiones y espacios)
            string cedulaFinal = mskCedula.Text.Replace("-", "").Trim();

            // Llamar al método de negocio con los datos del formulario
            bool resultado = negocioCliente.RegistrarCliente(
                cmbTipoIden.Text,
                cedulaFinal,
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


        private void cmbTipoIden_SelectedIndexChanged(object sender, EventArgs e)
        {

            mskCedula.Text = ""; // limpiar campo

            if (cmbTipoIden.SelectedValue != null)
            {
                string tipo = cmbTipoIden.Text;

                if (tipo == "CEDULA_FISICA_NACIONAL")
                    mskCedula.Mask = "0-0000-0000";
                else if (tipo == "DIMEX")
                    mskCedula.Mask = "0000000000000";
                else if (tipo == "PASAPORTE")
                    mskCedula.Mask = "AAAAAAAAAAAAAAA";
            }
        }

        private void btnRegistrarSegundoVehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                string placa = txtPlaca.Text.Trim();
                string tipoVehiculo = cmbTipoVehiculo.Text;
                string numeroIdCliente = mskCedula.Text.Replace("-", "").Trim(); // Normalización
                string marca = cmbMarca.Text;
                string color = cmbColor.Text;

                bool resultado = nEntradaVehiculo.RegistrarSegundoVehiculo(
                    placa,
                    tipoVehiculo,
                    numeroIdCliente,
                    marca,
                    color
                );

                if (resultado)
                {
                    MessageBox.Show("Vehículo registrado correctamente ✅");
                }
                else
                {
                    MessageBox.Show("Error al registrar el vehículo ❌");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void mskCedula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!mskCedula.MaskCompleted)
                {
                    MessageBox.Show("Debe ingresar la cédula completa con guiones.");
                    return;
                }

                string cedulaIngresada = mskCedula.Text.Replace("-", "").Trim();

                NCliente nCliente = new NCliente();
                var datosPadron = nCliente.BuscarPadronElectoral(cedulaIngresada);

                if (datosPadron != null)
                {
                    txtNombre.Text = datosPadron.Nombre;
                    txtApellidos.Text = datosPadron.Apellido;
                }
                else
                {
                    MessageBox.Show("No se encontró la cédula en el padrón.");
                }
            }
        }
    }
}
