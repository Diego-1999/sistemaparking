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
    public partial class EstablecerTarifa : Form
    {
        public EstablecerTarifa()
        {
            InitializeComponent();
            this.CargarComboTipoVehiculo();
        }

        //Cargar ComboBox Tipo Vehiculo
        private void CargarComboTipoVehiculo()
        {
            cmbTipoVehiculo.DataSource = new NTiposVehiculo().ListarTipoVehiculo();
            cmbTipoVehiculo.DisplayMember = "Descripcion";
            cmbTipoVehiculo.ValueMember = "Codigo";
            cmbTipoVehiculo.SelectedIndex = -1; //Sin selección inicial
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {

            // Instanciamos la capa negocio
            NTarifa ntarifa = new NTarifa();

            // Validamos y convertimos antes de pasar a la capa negocio
            if (decimal.TryParse(txtMontoHora.Text, out decimal montoHora) &&
                int.TryParse(txtFranccionMinuto.Text, out int fraccionMinuto) &&
                decimal.TryParse(txtMontoFranccionMinuto.Text, out decimal montoFraccionMinuto))
            {
                bool ok = ntarifa.RegistroTarifa(
                    txtDescripcion.Text,       // string
                    montoHora,                 // decimal
                    fraccionMinuto,            // int
                    montoFraccionMinuto,       // decimal
                    cmbTipoVehiculo.Text       // string
                );

                if (ok)
                    MessageBox.Show("tarifa registrada correctamente");
                else
                    MessageBox.Show("No se pudo registrar la tarifa");
            }
            else
            {
                MessageBox.Show("Ingrese valores numéricos válidos en los campos de monto y fracción.");
            }
        }

        private void EstablecerTarifa_Load(object sender, EventArgs e)
        {
            txtDescripcion.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDescripcion.Clear();
            txtMontoHora.Clear();
            txtFranccionMinuto.Clear();
            txtMontoFranccionMinuto.Clear();
            cmbTipoVehiculo.SelectedIndex = -1;

        }
    }
}
