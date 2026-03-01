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
        }

        NCliente nCliente = new NCliente();

   
        private void Clientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
           
        }

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

            dgwClientes.DataSource = clientes;
        }

        private void btnEditar_Click(object sender, EventArgs e)
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
        
    }
}
