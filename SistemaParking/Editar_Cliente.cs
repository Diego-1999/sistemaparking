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

        //Cargar ComboBox
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
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar ❌");
            }

        }
    }
}
