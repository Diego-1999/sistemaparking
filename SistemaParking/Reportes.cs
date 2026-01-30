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
using static SistemaParking.Negocio.NReportes;

namespace SistemaParking
{
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime fechaInicial = dtpFechaInicial.Value;
            DateTime fechaFinal = dtpFechaFinal.Value;

            var negocio = new NReportes();
            var reporte = negocio.GenerarReporte(fechaInicial, fechaFinal);

            dgvReporte.DataSource = reporte; // Mostrar directamente en DataGridView

            // Ajustes visuales
            dgvReporte.Columns["Vehiculo"].HeaderText = "Vehículo"; 
            dgvReporte.Columns["TipoVehiculo"].HeaderText = "Tipo de Vehículo";
            dgvReporte.Columns["Entrada"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvReporte.Columns["Salida"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvReporte.Columns["TotalPagar"].DefaultCellStyle.Format = "N2";
            dgvReporte.Columns["TotalPagar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvReporte.AutoResizeColumns();
            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


        }
    }
}
