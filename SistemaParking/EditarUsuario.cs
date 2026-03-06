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
    public partial class EditarUsuario : Form
    {
        private EUsuario usuario;
        public EditarUsuario(EUsuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            CargarComboRol();
            CargarComboTipoID();
            CargarDatosUsuario();

        }

        private void CargarComboTipoID()
        {
            cmbTipoIden.DataSource = new NTipoID().ListarTipoId();
            cmbTipoIden.DisplayMember = "descripcion";
            cmbTipoIden.ValueMember = "tipo_id";
            cmbTipoIden.SelectedIndex = -1;
        }

        private void CargarComboRol()
        {
            cmbRol.DataSource = new NRol().ListarRol();
            cmbRol.DisplayMember = "nombre_rol";
            cmbRol.ValueMember = "id_rol";
            cmbRol.SelectedIndex = -1;
        }

        private void CargarDatosUsuario()
        {
            mskcedula.Text = usuario.numero_id;
            txtNombre.Text = usuario.nombre;
            txtApellidos.Text = usuario.apellido;
            txtTelefono.Text = usuario.telefono;
            txtEmail.Text = usuario.correo;
            txtUsuario.Text = usuario.usuario;
            txtContrasena.Text = usuario.Contrasena;

            // Combos
            cmbTipoIden.SelectedValue = usuario.tipo_id;
            cmbRol.SelectedValue = usuario.IdRol;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var editarusuario = new EUsuario
            {
                numero_id = mskcedula.Text,
                nombre = txtNombre.Text,
                apellido = txtApellidos.Text,
                telefono = txtTelefono.Text,
                correo = txtEmail.Text,
                usuario = txtUsuario.Text,
                Contrasena = txtContrasena.Text, // texto plano, se re-hashea en NUsuario
                tipo_id = cmbTipoIden.SelectedValue.ToString(),
                IdRol = (int)cmbRol.SelectedValue
            };

            try
            {
                NUsuario negocioUsuario = new NUsuario();
                if (negocioUsuario.EditarUsuario(editarusuario))
                {
                    MessageBox.Show("Usuario editado correctamente ✅", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo editar el usuario ❌", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Aquí capturas el error real que DAL lanzó
                MessageBox.Show("Error al actualizar usuario: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
