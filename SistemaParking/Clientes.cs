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
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
            ConfigurarToolTips();
             CargarClientes();
           
        }

        NCliente nCliente = new NCliente();


        private void btnBuscar_Click(object sender, EventArgs e)
        {

            string busqueda = txtNombreCedula.Text.Trim();
            var clientes = nCliente.BuscarClientes(busqueda);
            MostrarEnGrid(clientes);
           
        }

        private void CargarClientes()
        {
            var clientes = nCliente.MostrarClientes();
            MostrarEnGrid(clientes);
        }

        private void MostrarEnGrid(List<ECliente> clientes)
        {
            dgwClientes.AutoGenerateColumns = false;
            dgwClientes.Columns.Clear();

            dgwClientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cédula", DataPropertyName = "Cedula" });
            dgwClientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombre", DataPropertyName = "Nombre" });
            dgwClientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Apellido", DataPropertyName = "Apellido" });
            dgwClientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Teléfono", DataPropertyName = "Telefono" });
            dgwClientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Correo", DataPropertyName = "Correo" });

            // Mostrar solo el primer vehículo
            dgwClientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Placa", DataPropertyName = "Placa" });
            dgwClientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Marca", DataPropertyName = "Marca" });
            dgwClientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Color", DataPropertyName = "Color" });
            dgwClientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tipo Vehículo", DataPropertyName = "TipoVehiculo" });

            dgwClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwClientes.DataSource = clientes;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgwClientes.CurrentRow != null)
                {
                    ECliente clienteSeleccionado = (ECliente)dgwClientes.CurrentRow.DataBoundItem;


                    Editar_Cliente frmEditar = new Editar_Cliente(clienteSeleccionado);

                    Menu menu = (Menu)this.ParentForm;
                    menu.AbrirFormPanel(frmEditar);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un cliente para editar.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al exportar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                   
        }


        private void ConfigurarToolTips()
        {
            ToolTip toolTip1 = new ToolTip();

            // Configuración 
            toolTip1.AutoPopDelay = 5000;   // tiempo visible en ms
            toolTip1.InitialDelay = 500;    // retraso antes de aparecer
            toolTip1.ReshowDelay = 200;     // retraso entre apariciones
            toolTip1.ShowAlways = true;     // mostrar incluso si el formulario no está activo

            // Asigna ToolTip a controles
            toolTip1.SetToolTip(this.btnBuscar, "Buscar Cliente");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgwClientes.CurrentRow != null)
                {
                    // 1. Obtener entidad cliente desde el DataGrid
                    ECliente clienteSeleccionado = (ECliente)dgwClientes.CurrentRow.DataBoundItem;

                    // 2. Confirmación
                    var confirmResult = MessageBox.Show(
                        $"¿Está seguro de eliminar al cliente con ID {clienteSeleccionado.Cedula}?",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirmResult == DialogResult.Yes)
                    {
                         NCliente clienteService = new NCliente();

                      

                        // 3. Ejecutar eliminación pasando la entidad
                        bool eliminado = clienteService.EliminarCliente(clienteSeleccionado);

                        if (eliminado)
                        {
                            MessageBox.Show("Cliente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarClientes(); // refrescar DataGrid
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un cliente para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }



        //validaciones

    }
}
