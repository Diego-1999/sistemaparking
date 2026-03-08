using SistemaParking.Entidad;
using SistemaParking.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            txtContrasena.UseSystemPasswordChar = true;
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
            try
            {
                txtContrasena.UseSystemPasswordChar = true;

                //validaciones de campos
                if (cmbTipoIden.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un tipo de identificación", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!mskcedula.MaskCompleted)
                {
                    MessageBox.Show("Necesita ingresar la cédula", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    MessageBox.Show("Campo nombre incompleto", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (string.IsNullOrEmpty(txtApellidos.Text))
                {
                    MessageBox.Show("Campo apellidos incompleto", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (string.IsNullOrEmpty(txtTelefono.Text)) //valida espacio vacio del telefono
                {
                    MessageBox.Show("Campo teléfono incompleto", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!ValidarTelefono(txtTelefono.Text)) // valida solo 8 numero y no permite letras
                {
                    MessageBox.Show("Teléfono inválido", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (string.IsNullOrEmpty(txtEmail.Text)) //valida espacio vacio del correo
                {
                    MessageBox.Show("Campo correo incompleto", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!IsValidEmail(txtEmail.Text)) // valida formato correcto del correo
                {
                    MessageBox.Show("Correo inválido", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (string.IsNullOrEmpty(txtUsuario.Text))
                {
                    MessageBox.Show("Campo Usuario incompleto ", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (string.IsNullOrEmpty(txtContrasena.Text) || txtContrasena.Text == "System.Byte[]")
                {
                    MessageBox.Show("Debe cambiar la contraseña del usuario", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (cmbRol.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un rol", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
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
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
            
        }

        //Validaciones

        //valida correo
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        //valida numero de telefono
        public static bool ValidarTelefono(string strNumber)
        {
            Regex regex = new Regex(@"^[0-9]{8}$");
            Match match = regex.Match(strNumber);

            if (match.Success)
                return true;
            else
                return false;
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
