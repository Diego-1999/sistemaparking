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
    public partial class Registrar_Usuario : Form
    {

        NUsuario negocioUsuario = new NUsuario();

        public Registrar_Usuario()
        {
            InitializeComponent();
            this.CargarComboRol();
            this.CargarComboTipoId();

            ConfigurarToolTips();
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
            try
            {
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
                else if (string.IsNullOrEmpty(txtContrasena.Text))
                {
                    MessageBox.Show("Campo Usuario incompleto ", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (cmbRol.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un rol", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Normalizar la cédula (quitar guiones y espacios)
                    string cedulaFinal = mskcedula.Text.Replace("-", "").Trim();

                    bool resultado = negocioUsuario.RegistrarUsuario(
                    cmbTipoIden.Text,
                    cedulaFinal,
                    txtNombre.Text,
                    txtApellidos.Text,
                    txtTelefono.Text,
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
                        Menu menu = (Menu)this.ParentForm;
                        menu.AbrirFormPanel(new Inicio());

                    }
                    else
                    {
                        MessageBox.Show("Error al registrar  ❌",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }        
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            mskcedula.Clear();
            txtEmail.Clear();
            txtUsuario.Clear();
            txtContrasena.Clear();
            cmbTipoIden.SelectedIndex = -1;
            cmbRol.SelectedIndex = -1;
        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {
            txtContrasena.UseSystemPasswordChar = true;
        }

        private void btnVerUsuarios_Click(object sender, EventArgs e)
        {
            // Instancia del formulario que necesito llamar para mostrar en el panel
            Usuarios frmUsuario = new Usuarios();

            // se llama al método del formulario principal
            Menu menu = (Menu)this.ParentForm;
            menu.AbrirFormPanel(frmUsuario);
        }

        private void cmbTipoIden_SelectedIndexChanged(object sender, EventArgs e)
        {
            mskcedula.Text = ""; // limpiar campo

            if (cmbTipoIden.SelectedValue != null)
            {
                string tipo = cmbTipoIden.Text;

                if (tipo == "CEDULA_FISICA_NACIONAL")
                    mskcedula.Mask = "0-0000-0000";
                else if (tipo == "DIMEX")
                    mskcedula.Mask = "0000000000000";
                else if (tipo == "PASAPORTE")
                    mskcedula.Mask = "AAAAAAAAAAAAAAA";
            }
        }

        private void mskcedula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!mskcedula.MaskCompleted)
                {
                    MessageBox.Show("Debe ingresar la cédula completa con guiones.");
                    return;
                }

                string cedulaIngresada = mskcedula.Text.Replace("-", "").Trim();

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

        private void ConfigurarToolTips()
        {
            ToolTip toolTip1 = new ToolTip();

            // Configuración 
            toolTip1.AutoPopDelay = 5000;   // tiempo visible en ms
            toolTip1.InitialDelay = 500;    // retraso antes de aparecer
            toolTip1.ReshowDelay = 200;     // retraso entre apariciones
            toolTip1.ShowAlways = true;     // mostrar incluso si el formulario no está activo

            // Asigna ToolTip a controles
            toolTip1.SetToolTip(this.mskcedula, "Enter: para traer los datos");
            
        }

        private void mskcedula_KeyPress(object sender, KeyPressEventArgs e)
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
