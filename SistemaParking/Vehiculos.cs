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
    public partial class Vehiculos : Form
    {
        public event Action EntradaEliminada;
        private NEntradaVehiculo negocioVehiculo = new NEntradaVehiculo();

        public Vehiculos()
        {
            InitializeComponent();
            CargarVehiculos();
        }

        private void CargarVehiculos()
        {
            dgvVehiculo.DataSource = negocioVehiculo.MostrarVehiculosEnParqueo();
            dgvVehiculo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Encabezados amigables
            dgvVehiculo.Columns["Placa"].HeaderText = "Placa";
            dgvVehiculo.Columns["TipoVehiculo"].HeaderText = "Tipo";
            dgvVehiculo.Columns["FechaHoraEntrada"].HeaderText = "Entrada";
            dgvVehiculo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //ajustar las tablas en el data
        }

        // Método para refrescar cuando entra o sale un vehículo
        public void RefrescarVehiculos()
        {
            CargarVehiculos();
        }

        private void Vehiculos_Load(object sender, EventArgs e)
        {
            CargarVehiculos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVehiculo.CurrentRow != null)
                {
                    int idEntrada = Convert.ToInt32(dgvVehiculo.CurrentRow.Cells["IdEntrada"].Value);
                    string placa = dgvVehiculo.CurrentRow.Cells["Placa"].Value.ToString();

                    var confirmacion = MessageBox.Show(
                        $"¿Seguro que desea eliminar la entrada del vehículo con placa {placa}?",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirmacion == DialogResult.Yes)
                    {
                        bool resultado = negocioVehiculo.EliminarEntrada(idEntrada);

                        if (resultado)
                        {
                            MessageBox.Show($"Entrada del vehículo {placa} eliminada correctamente ✅");
                            CargarVehiculos();


                            foreach (Form frm in Application.OpenForms)
                            {
                                if (frm is Menu menuForm)
                                {
                                    menuForm.ActualizarLabels();
                                    break;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar la entrada ❌");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una entrada en la lista.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al exportar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }   
    }
}
