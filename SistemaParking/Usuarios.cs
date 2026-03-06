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
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
            CargarUsuarios();
        }


        private void CargarUsuarios()
        {
            NUsuario negocioUsuario = new NUsuario();
            dgwUsuario.DataSource = negocioUsuario.MostrarUsuarios();
            dgwUsuario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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
            try
            {
                string criterio = txtBusqueda.Text.Trim();
                NUsuario negocioUsuario = new NUsuario();
                var resultado = negocioUsuario.BuscarUsuarios(criterio);
                dgwUsuario.DataSource = resultado;
                dgwUsuario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajustar colmnas en DataGridView
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception)
            {

                throw;
            }
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgwUsuario.CurrentRow != null)
            {
                // Obtener el usuario seleccionado
                EUsuario usuarioSeleccionado = (EUsuario)dgwUsuario.CurrentRow.DataBoundItem;

                // Crear el formulario de edición
                EditarUsuario frmEditar = new EditarUsuario(usuarioSeleccionado);

                // Abrirlo dentro del panel del menú principal
                Menu menu = (Menu)this.ParentForm;
                menu.AbrirFormPanel(frmEditar);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario para editar.");
            }
        }
    }
}
