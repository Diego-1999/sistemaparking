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
    public partial class Establecer_TarifaReserva : Form
    {
        public Establecer_TarifaReserva()
        {
            InitializeComponent();
            CargarComboTipoVehiculo();
            CargarComboTiempoReservas();
        }

        private void CargarComboTipoVehiculo()
        {
            cmbTipoVehiculo.DataSource = new NTiposVehiculo().ListarTipoVehiculo();
            cmbTipoVehiculo.DisplayMember = "Descripcion";
            cmbTipoVehiculo.ValueMember = "Codigo";
            cmbTipoVehiculo.SelectedIndex = -1; //Sin selección inicial
        }

        private void CargarComboTiempoReservas()
        {
            cmbTiempoReserva.DataSource = new NReserva().ListarReserva();
            cmbTiempoReserva.DisplayMember = "descripcion_reserva";
            cmbTiempoReserva.ValueMember = "id_reserva";
            cmbTiempoReserva.SelectedIndex = -1;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            //instanciamos la clase negocio
            NReserva nReserva = new NReserva();

            if(int.TryParse(txtMonto.Text, out int monto) ){
                bool ok = nReserva.RegistrarTarifaReserva(
                    txtDescripcion.Text,
                    monto,
                    cmbTiempoReserva.Text,
                    cmbTipoVehiculo.Text);


                txtDescripcion.Clear();
                txtMonto.Clear();
                cmbTiempoReserva.SelectedIndex = -1;
                cmbTipoVehiculo.SelectedIndex = -1;

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

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            txtDescripcion.Clear();
            txtMonto.Clear();
            cmbTiempoReserva.SelectedIndex = -1;
            cmbTipoVehiculo.SelectedIndex = -1;
        }
    }
}
