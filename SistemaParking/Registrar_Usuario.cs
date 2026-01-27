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
    public partial class Registrar_Usuario : Form
    {
        public Registrar_Usuario()
        {
            InitializeComponent();
            this.CargarComboRol();
            this.CargarComboTipoId();
        }

        //Cargar ComboBox Tipo id
        private void CargarComboRol()
        {
            cmbRol.DataSource = new NRol().ListarRol();
            cmbRol.DisplayMember = "nombre_rol";
            cmbRol.ValueMember = "id_rol";
            cmbRol.SelectedIndex = -1; //Sin selección inicial
        }

        //Cargar ComboBox Tipo id
        private void CargarComboTipoId()
        {
            cmbTipoIden.DataSource = new NTipoID().ListarTipoId();
            cmbTipoIden.DisplayMember = "tipo_id";
            cmbTipoIden.ValueMember = "descripcion";
            cmbTipoIden.SelectedIndex = -1; //Sin selección inicial
        }

        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            NUsuario negocioUsuario = new NUsuario();

            bool resultado = negocioUsuario.RegistrarUsuario(
            cmbTipoIden.Text,
            txtNombre.Text,
            txtApellidos.Text,
            txtTelefono.Text,
            txtCedula.Text,
            txtEmail.Text,
            txtUsuario.Text,
            txtContrasena.Text,
            cmbRol.Text
            );

            // Mostrar resultado al usuario
            if (resultado)
            {
                MessageBox.Show("Usuario registrado correctamente ✅",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Error al registrar  ❌",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtCedula.Clear();
            txtEmail.Clear();
            txtUsuario.Clear();
            txtContrasena.Clear();
            cmbTipoIden.SelectedIndex = -1;
            cmbRol.SelectedIndex = -1;
        }
    }
}
