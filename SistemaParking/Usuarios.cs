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
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }


        private void CargarUsuarios()
        {
            NUsuario negocioUsuario = new NUsuario();
            dgwUsuario.DataSource = negocioUsuario.MostrarUsuarios();

            // Encabezados amigables
            dgwUsuario.Columns["numero_id"].HeaderText = "Cédula";
            dgwUsuario.Columns["tipo_id"].HeaderText = "Tipo ID";
            dgwUsuario.Columns["nombre"].HeaderText = "Nombre";
            dgwUsuario.Columns["apellido"].HeaderText = "Apellido";
            dgwUsuario.Columns["usuario"].HeaderText = "Usuario";
            dgwUsuario.Columns["telefono"].HeaderText = "Teléfono";
            dgwUsuario.Columns["correo"].HeaderText = "Correo";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string criterio = txtBusqueda.Text.Trim();
            NUsuario negocioUsuario = new NUsuario();
            var resultado = negocioUsuario.BuscarUsuarios(criterio);
            dgwUsuario.DataSource = resultado;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgwUsuario.CurrentRow != null)
            {
                // Obtener el numero_id de la fila seleccionada
                string cedula = dgwUsuario.CurrentRow.Cells["numero_id"].Value.ToString();

                // Confirmar con el usuario
                var confirmacion = MessageBox.Show(
                    $"¿Seguro que desea eliminar al usuario con cédula {cedula}?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.Yes)
                {
                    NUsuario negocioUsuario = new NUsuario();
                    bool resultado = negocioUsuario.EliminarUsuario(cedula);

                    if (resultado)
                    {
                        MessageBox.Show("Usuario eliminado correctamente ✅");
                        CargarUsuarios(); // refrescar la grilla
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el usuario ❌");
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario en la lista.");
            }
        }
    }
}
