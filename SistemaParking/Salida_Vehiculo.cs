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
    public partial class Salida_Vehiculo : Form
    {
        public Salida_Vehiculo()
        {
            InitializeComponent();
        }

        private void Salida_Vehiculo_Load(object sender, EventArgs e)
        {
            txtPlaca.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPlaca.Clear();
            txtPlaca.Focus();
        }

        private void btnRegistrarSalida_Click(object sender, EventArgs e)
        {
            try
            {
                NSalidaVehiculo negocio = new NSalidaVehiculo(); //se encarga de procesar la salida y calcular el total
                decimal total = negocio.RegistrarSalida(txtPlaca.Text, SesionActual.Usuario.NumeroIdColaborador); //se captura la placa y el usuario actual

                MessageBox.Show($"Total a pagar: ₡{total}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
