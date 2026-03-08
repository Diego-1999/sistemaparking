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
    public partial class Registro_Cliente : Form
    {
        public Registro_Cliente()
        {
            InitializeComponent();
            this.CargarComboTipoVehiculo();
            this.CargarComboMarca();
            this.CargarComboColor();
            this.CargarComboTipoId();
            ConfigurarToolTips();

        }

        //intancias a capa negocio
        NEntradaVehiculo nEntradaVehiculo = new NEntradaVehiculo();
        NCliente nCliente = new NCliente();

        private void Registro_Cliente_Load(object sender, EventArgs e)
        {
            txtNombre.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //Limpiar campos 
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

        
        
        private void CargarComboTipoVehiculo()
        {
            //Cargar ComboBox Tipo Vehiculo
            cmbTipoVehiculo.DataSource = new NTiposVehiculo().ListarTipoVehiculo();
            cmbTipoVehiculo.DisplayMember = "Descripcion";
            cmbTipoVehiculo.ValueMember = "Codigo";
            cmbTipoVehiculo.SelectedIndex = -1; //Sin selección inicial
        }

        
        private void CargarComboMarca()
        {
            //Cargar ComboBox Marca
            cmbMarca.DataSource = new NMarca().ListarMarca();
            cmbMarca.DisplayMember = "nombre_marca";
            cmbMarca.ValueMember = "id_marca";
            cmbMarca.SelectedIndex = -1; //Sin selección inicial
        }

        
        private void CargarComboColor()
        {
            //Cargar ComboBox Color
            cmbColor.DataSource = new NColor().ListarColor();
            cmbColor.DisplayMember = "nombre_color";
            cmbColor.ValueMember = "id_color";
            cmbColor.SelectedIndex = -1; //Sin selección inicial
        }

        
        private void CargarComboTipoId()
        {
            //Cargar ComboBox Tipo id
            cmbTipoIden.DataSource = new NTipoID().ListarTipoId();
            cmbTipoIden.DisplayMember = "tipo_id";
            cmbTipoIden.ValueMember = "descripcion";
            cmbTipoIden.SelectedIndex = -1; //Sin selección inicial
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                //validaciones de campos
                if (cmbTipoIden.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un tipo de identificación", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!mskCedula.MaskCompleted)
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
                else if (cmbMarca.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un tipo de vehículo", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (string.IsNullOrEmpty(txtPlaca.Text)) // valida placa vacia
                {
                    MessageBox.Show("Campo placa incompleto", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!ValidarPlaca(txtPlaca.Text)) // valida formato placa correcto
                {
                    MessageBox.Show("Placa inválida", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                }
                else if (cmbTipoVehiculo.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un tipo de vehículo", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (cmbColor.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un color", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Normalizar la cédula quitar guiones y espacios
                    string cedulaFinal = mskCedula.Text.Replace("-", "").Trim();

                    // Llamar al método de negocio con los datos del formulario
                    bool resultado = nCliente.RegistrarCliente(
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
                        Menu menu = (Menu)this.ParentForm;
                        menu.AbrirFormPanel(new Registro_Vehiculo());
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar cliente ❌",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }                           
        }



        private void btnRegistrarSegundoVehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                //validaciones de campos
                if (cmbTipoIden.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un tipo de identificación", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!mskCedula.MaskCompleted)
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
                else if (cmbMarca.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un tipo de vehículo", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (string.IsNullOrEmpty(txtPlaca.Text)) // valida placa vacia
                {
                    MessageBox.Show("Campo placa incompleto", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!ValidarPlaca(txtPlaca.Text)) // valida formato placa correcto
                {
                    MessageBox.Show("Placa inválida", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                }
                else if (cmbTipoVehiculo.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un tipo de vehículo", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (cmbColor.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un tipo de vehículo", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string placa = txtPlaca.Text.Trim();
                    string tipoVehiculo = cmbTipoVehiculo.Text;
                    string numeroIdCliente = mskCedula.Text.Replace("-", "").Trim(); // remplazar a vacio el guion
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

                        Menu menu = (Menu)this.ParentForm;
                        menu.AbrirFormPanel(new Registro_Vehiculo());
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar el vehículo ❌");
                    }
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

        //valida placa
        public static bool ValidarPlaca(string strNumber)
        {
            Regex regex = new Regex(@"(^[A-Z]{3}[0-9]{3}$)|(^[0-9]{6}$)");
            Match match = regex.Match(strNumber);

            if (match.Success)
                return true;
            else
                return false;
        }
 
        private void cmbTipoIden_SelectedIndexChanged(object sender, EventArgs e)
        {
            mskCedula.Text = ""; // limpiar campo

            if (cmbTipoIden.SelectedValue != null)
            {
                string tipo = cmbTipoIden.Text;

                //Validaciones de mascara del campo cedula
                if (tipo == "CEDULA_FISICA_NACIONAL")
                    mskCedula.Mask = "0-0000-0000";
                else if (tipo == "DIMEX")
                    mskCedula.Mask = "0000000000000";
                else if (tipo == "PASAPORTE")
                    mskCedula.Mask = "AAAAAAAAAAAAAAA";
            }
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
            toolTip1.SetToolTip(this.mskCedula, "Enter: para traer los datos");
            toolTip1.SetToolTip(this.btnRegistrarSegundoVehiculo, "Registrar otro vehiculo del mismo cliente");
        }

        private void mskCedula_KeyPress(object sender, KeyPressEventArgs e)
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
