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
    public partial class EspaciosParqueo : Form
    {
        // Instanciamos la capa negocio
        NEspaciosParqueo nespacio = new NEspaciosParqueo();
        NTiposVehiculo nTiposVehiculo = new NTiposVehiculo();

        public EspaciosParqueo()
        {
            InitializeComponent();
            CargarComboTipoVehiculo();
        }

        private void BtnGuardarEspacio_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TxtNumeroEspacios.Text))
                {
                    MessageBox.Show("Campo numero de espacios del parqueo incompleto", "Aceptar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                if (int.TryParse(TxtNumeroEspacios.Text, out int numeroEspacio))
                {
                    bool ok = nespacio.RegistroEspacio(
                        numeroEspacio,
                        cmbTipoVehiculo.SelectedValue.ToString()

                    );

                    if (ok)
                        MessageBox.Show("Datos registrados correctamente");
                    else
                        MessageBox.Show("No se pudo registrar ");
                }
                else
                {
                    MessageBox.Show("Ingrese valores numéricos válidos en el campos numero espacio.");
                }
            }
            catch (Exception)
            {

                throw;
            }

            
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            TxtNumeroEspacios.Clear();
            cmbTipoVehiculo.SelectedIndex = -1;
            TxtNumeroEspacios.Focus();
        }


        //Cargar ComboBox TipoVehiculo
        private void CargarComboTipoVehiculo()
        {
            cmbTipoVehiculo.DataSource = new NTiposVehiculo().ListarTipoVehiculo();
            cmbTipoVehiculo.DisplayMember = "Descripcion";
            cmbTipoVehiculo.ValueMember = "Codigo";
            cmbTipoVehiculo.SelectedIndex = -1; //Sin selección inicial
        }

        private void EspaciosParqueo_Load(object sender, EventArgs e)
        {
            TxtNumeroEspacios.Focus();
        }

        private void TxtNumeroEspacios_KeyPress(object sender, KeyPressEventArgs e)
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
