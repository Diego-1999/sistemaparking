using ClosedXML.Excel;
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

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los datos del reporte según las fechas seleccionadas
                NReportes negocioReportes = new NReportes();
                List<EReportes> reporte = negocioReportes.GenerarReporte(dtpFechaInicial.Value, dtpFechaFinal.Value);

                if (reporte.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar en el rango seleccionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Crear el archivo Excel
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Reporte");

                    // Encabezados
                    worksheet.Cell(1, 1).Value = "Vehículo";
                    worksheet.Cell(1, 2).Value = "Tipo Vehículo";
                    worksheet.Cell(1, 3).Value = "Entrada";
                    worksheet.Cell(1, 4).Value = "Salida";
                    worksheet.Cell(1, 5).Value = "Tarifa";
                    worksheet.Cell(1, 6).Value = "Cliente";
                    worksheet.Cell(1, 7).Value = "Total a Pagar";

                    // Datos
                    int fila = 2;
                    foreach (var item in reporte)
                    {
                        worksheet.Cell(fila, 1).Value = item.Vehiculo;
                        worksheet.Cell(fila, 2).Value = item.TipoVehiculo;
                        worksheet.Cell(fila, 3).Value = item.Entrada;
                        worksheet.Cell(fila, 4).Value = item.Salida;
                        worksheet.Cell(fila, 5).Value = item.Tarifa;
                        worksheet.Cell(fila, 6).Value = item.Cliente;
                        worksheet.Cell(fila, 7).Value = item.TotalPagar;
                        fila++;
                    }

                    // Ajustar columnas y formato de fechas
                    worksheet.Column(3).Style.DateFormat.Format = "dd/MM/yyyy HH:mm";
                    worksheet.Column(4).Style.DateFormat.Format = "dd/MM/yyyy HH:mm";
                    worksheet.Columns().AdjustToContents();

                    // Guardar archivo con SaveFileDialog
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Excel Workbook|*.xlsx",
                        Title = "Guardar Reporte en Excel",
                        FileName = "ReporteParking.xlsx"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Reporte exportado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
    
}