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
           // dgwClientes.DataSource = negocio.MostrarClientes();
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
            // Mostrar todos los vehículos en filas separadas
            var lista = clientes.SelectMany(c => c.Vehiculos.Select(v => new
            {
                c.Cedula,
                c.TipoId,
                c.Nombre,
                c.Apellido,
                c.Telefono,
                c.Correo,
                v.Placa,
                v.TipoVehiculo,
                v.Marca,

                v.Color
            })).ToList();

            dgwClientes.AutoGenerateColumns = true;
            dgwClientes.DataSource = lista;
        }
    }
}
