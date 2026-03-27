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
    public partial class Editar_Cliente : Form
    {
        private ECliente cliente;
        public Editar_Cliente(ECliente cliente)
        {
            InitializeComponent();
            this.CargarComboTipoVehiculo();
            this.CargarComboTipoMarca();
            this.CargarComboTipoID();
            this.CargarComboColor();
            this.cliente = cliente;

            CargarDatos();
        }
   
        private void CargarComboTipoID()
        {

            cmbTipoIden.DataSource = new NTipoID().ListarTipoId();
            cmbTipoIden.DisplayMember = "descripcion";
            cmbTipoIden.ValueMember = "tipo_id";
            cmbTipoIden.SelectedIndex = -1;

        }

        //Cargar ComboBox TipoVehiculo
        private void CargarComboTipoVehiculo()
        {
            cmbTipoVehiculo.DataSource = new NTiposVehiculo().ListarTipoVehiculo();
            cmbTipoVehiculo.DisplayMember = "Descripcion";
            cmbTipoVehiculo.ValueMember = "Codigo";
            cmbTipoVehiculo.SelectedIndex = -1; //Sin selección inicial
        }

        private void CargarComboTipoMarca()
        {
            cmbMarca.DataSource = new NMarca().ListarMarca();
            cmbMarca.DisplayMember = "nombre_marca";
            cmbMarca.ValueMember = "id_marca";
            cmbMarca.SelectedIndex = -1;
        }

        private void CargarComboColor()
        {
            cmbColor.DataSource = new NColor().ListarColor();
            cmbColor.DisplayMember = "nombre_color";
            cmbColor.ValueMember = "id_color";
            cmbColor.SelectedIndex = -1;
        }
        private void CargarDatos()
        {
            mskCedula.Text = cliente.Cedula;
            txtNombre.Text = cliente.Nombre;
            txtApellidos.Text = cliente.Apellido;
            txtTelefono.Text = cliente.Telefono;
            txtEmail.Text = cliente.Correo;

            if (!string.IsNullOrEmpty(cliente.TipoId))
                cmbTipoIden.SelectedValue = cliente.TipoId;

            if (cliente.Vehiculos != null && cliente.Vehiculos.Count > 0)
            {
                EVehiculo v = cliente.Vehiculos[0];
                txtPlaca.Text = v.Placa;

                if (!string.IsNullOrEmpty(v.Codigo))
                    cmbTipoVehiculo.SelectedValue = v.Codigo;

                if (v.IdMarca > 0)
                    cmbMarca.SelectedValue = v.IdMarca;

                if (v.IdColor > 0)
                    cmbColor.SelectedValue = v.IdColor;
            }
        }



        private void btnEditar_Click(object sender, EventArgs e)
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
                    // Actualizar datos del cliente
                    cliente.Nombre = txtNombre.Text;
                    cliente.Apellido = txtApellidos.Text;
                    cliente.Telefono = txtTelefono.Text;
                    cliente.Correo = txtEmail.Text;
                    cliente.TipoId = cmbTipoIden.SelectedValue.ToString();

                    // Actualizar datos del vehículo
                    if (cliente.Vehiculos != null && cliente.Vehiculos.Count > 0)
                    {
                        EVehiculo v = cliente.Vehiculos[0];
                        v.Placa = txtPlaca.Text;
                        v.Codigo = cmbTipoVehiculo.SelectedValue.ToString();
                        v.IdMarca = Convert.ToInt32(cmbMarca.SelectedValue);
                        v.IdColor = Convert.ToInt32(cmbColor.SelectedValue);
                    }


                    // Guardar cambios
                    NCliente negocio = new NCliente();
                    bool resultado = negocio.EditarClienteYVehiculo(cliente);

                    if (resultado)
                    {
                        MessageBox.Show("Cliente y vehículo actualizados correctamente ✅");
                        this.DialogResult = DialogResult.OK;

                        Menu menu = (Menu)this.ParentForm;
                        menu.AbrirFormPanel(new Clientes());
                        
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar ❌");
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
