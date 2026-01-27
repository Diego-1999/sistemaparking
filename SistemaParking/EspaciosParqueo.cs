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
        public EspaciosParqueo()
        {
            InitializeComponent();
           
        }

        private void BtnGuardarEspacio_Click(object sender, EventArgs e)
        {
            // Instanciamos la capa negocio
            NEspaciosParqueo nespacio = new NEspaciosParqueo();
            if (int.TryParse(TxtNumeroEspacios.Text, out int numeroEspacio))
            {
                bool ok = nespacio.RegistroEspacio(
                    numeroEspacio,
                    TxtTipoEspacio.Text

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

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            TxtNumeroEspacios.Clear();
            TxtTipoEspacio.Clear();
            TxtNumeroEspacios.Focus();
        }

        private void EspaciosParqueo_Load(object sender, EventArgs e)
        {
            TxtNumeroEspacios.Focus();
        }
    }
}
