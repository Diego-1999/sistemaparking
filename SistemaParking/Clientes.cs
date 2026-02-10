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

        private void txtNombreCedula_TextChanged(object sender, EventArgs e)
        {
            NCliente negocio = new NCliente();
            string busqueda = txtNombreCedula.Text.Trim();

            dgwClientes.DataSource = negocio.BuscarClientes(busqueda);
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            NCliente negocio = new NCliente();
            dgwClientes.DataSource = negocio.MostrarClientes();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            NCliente negocio = new NCliente();
            string busqueda = txtNombreCedula.Text.Trim();

            if (string.IsNullOrEmpty(busqueda))
            {
                // Si no hay texto, mostrar todos
                dgwClientes.DataSource = negocio.MostrarClientes();
            }
            else
            {
                // Si hay texto, mostrar filtrados
                dgwClientes.DataSource = negocio.BuscarClientes(busqueda);
            }
        }
    }
}
