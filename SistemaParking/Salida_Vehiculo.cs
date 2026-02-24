using Infraestructura;
using SistemaParking.Entidad;
using SistemaParking.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
                NSalidaVehiculo negocio = new NSalidaVehiculo();
                // Procesa la salida y calcula el total
                ETiqueteSalida tiquetesalida = negocio.GenerarTiqueteSalida(
                    txtPlaca.Text,
                    SesionActual.Usuario.NumeroIdColaborador
                    
                );
               
                // Generar PDF
                string ruta = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    "TiqueteSalida.pdf"
                );

                PdfHelper.GenerarTiqueteSalidaPDF(tiquetesalida, ruta);

                // Abrir PDF automáticamente
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = ruta,
                    UseShellExecute = true
                });

                txtPlaca.Clear();
                txtPlaca.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }

}

