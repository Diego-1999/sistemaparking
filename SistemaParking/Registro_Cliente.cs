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
        NCliente negocioCliente = new NCliente();

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
                if (!ValidarTelefono(txtTelefono))
                    return;

                //validaciones de campos
                if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellidos.Text))
                {
                    MessageBox.Show("Campos nombre o apellidos incompletos", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (string.IsNullOrEmpty(txtEmail.Text))
                {
                    ValidarCorreo(txtEmail.Text);               
                }
                else if (!mskCedula.MaskCompleted || cmbTipoIden.SelectedIndex == -1) 
                {
                    MessageBox.Show("Necesita ingresar la cédula", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (string.IsNullOrEmpty(txtPlaca.Text) || cmbTipoVehiculo.SelectedIndex == -1 || cmbMarca.SelectedIndex == -1 || cmbColor.SelectedIndex == -1)
                {
                    ValidarPlaca(txtPlaca.Text);
                    MessageBox.Show("Necesita ingresar el correo", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Normalizar la cédula quitar guiones y espacios
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

        private void btnRegistrarSegundoVehiculo_Click(object sender, EventArgs e)
        {
            try
            {

                if (!ValidarTelefono(txtTelefono))
                    return;


                //validaciones de campos
                if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellidos.Text))
                {
                    MessageBox.Show("Campos nombre o apellidos incompletos", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);                   
                }
                else if (string.IsNullOrEmpty(txtEmail.Text))
                {
                    ValidarCorreo(txtEmail.Text);                
                }
                else if (!mskCedula.MaskCompleted || cmbTipoIden.SelectedIndex == -1)
                {
                    MessageBox.Show("Necesita ingresar la cédula", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (string.IsNullOrEmpty(txtPlaca.Text) || cmbTipoVehiculo.SelectedIndex == -1 || cmbMarca.SelectedIndex == -1 || cmbColor.SelectedIndex == -1)
                {
                    ValidarPlaca(txtPlaca.Text);
                    MessageBox.Show("Necesita ingresar el correo", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private bool ValidarCorreo(string correo)
        {
            if (string.IsNullOrWhiteSpace(correo))
            {
                MessageBox.Show("Debe ingresar un correo electrónico.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Expresión regular simple para validar formato de correo
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(correo, patron))
            {
                MessageBox.Show("El correo electrónico no tiene un formato válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        public bool ValidarTelefono(TextBox txtTelefono)
        {
            string telefono = txtTelefono.Text.Trim();

            // Validar que no esté vacío
            if (string.IsNullOrEmpty(telefono))
            {
                MessageBox.Show("Debe ingresar un número de teléfono.",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return false;
            }

            // Validar que sean solo números
            if (!telefono.All(char.IsDigit))
            {
                MessageBox.Show("El número de teléfono solo debe contener dígitos.",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return false;
            }

            // Validar longitud  8 dígitos
            if (telefono.Length != 8)
            {
                MessageBox.Show("El número de teléfono debe tener exactamente 8 dígitos.",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return false;
            }

            return true; // válido
        }

        public bool ValidarPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
            {
                MessageBox.Show("Debe ingresar una placa.",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return false;
            }

            // Normalizar entrada
            placa = placa.Trim().ToUpper();

            // Patrón para carros (solo números, 6 dígitos)
            string patronCarroNumerico = @"^\d{6}$";

            // Patrón para motos (una letra + 6 dígitos)
            string patronMoto = @"^[A-Z]{1}\d{6}$";

            // Patrón para carros con 3 letras + 3 números
            string patronCarroAlfanumerico = @"^[A-Z]{3}\d{3}$";

            if (Regex.IsMatch(placa, patronCarroNumerico) ||
                Regex.IsMatch(placa, patronMoto) ||
                Regex.IsMatch(placa, patronCarroAlfanumerico))
            {
                return true; // válido
            }

            MessageBox.Show("La placa no tiene un formato válido.\nEjemplos válidos:\nCarro: 123456\nMoto: M123456\nCarro: ABC123",
                            "Validación",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
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
            toolTip1.SetToolTip(this.btnRegistrarSegundoVehiculo, "Registrar otro vehiculo del mismo cliente");
        }



    }
}
