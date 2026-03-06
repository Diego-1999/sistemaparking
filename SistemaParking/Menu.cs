using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using SistemaParking.Entidad;
using SistemaParking.Negocio;

namespace SistemaParking
{
    public partial class Menu : Form
    {

        //valiable de clase 
        private Color colorOriginalBtnEntrada;

        public Menu()
            {
                InitializeComponent();
                PersonalizarDiseno();
                ActualizarLabels();
                ConfigurarToolTips();
            
                Inicio inicio = new Inicio();              
                AbrirFormPanel(inicio);


            }

        NEspaciosParqueo nEspaciosParqueo = new NEspaciosParqueo();
        NEntradaVehiculo nEntradaVehiculo = new NEntradaVehiculo();

        //
        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btndesplegar_Click(object sender, EventArgs e)
        {
            //Evento para menu desplegable
            if(MenuVertical.Width == 250)
            {
                MenuVertical.Width = 70;
            }
            else
            {
                MenuVertical.Width = 250;
            }
        }

        private void PersonalizarDiseno()
        {
            //Ocultamos los submenu
            panelConf.Visible = false;
        }

        private void OcultarSubMenu()
        {
            if (panelConf.Visible == true) //si es visible
            {
                panelConf.Visible = false; //lo ocultamos
            }
        }

        private void MostrarSubMenu(Panel submenu)
        {
            if (panelConf.Visible == false) //si no es visible
            {
                OcultarSubMenu();
                panelConf.Visible = true; //lo mostramos
            }
            else
                submenu.Visible = false; 
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
           //boton para cerrar la aplicacion
            Application.Exit();
        }


        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            //metodo para poder arrastrar el programa
              ReleaseCapture();
              SendMessage(this.Handle,0x112,0xf012,0);
        }


        //Funcion cargar formulario hijo dentro del panel contenedor
        public void AbrirFormPanel(object FormHijo)
        {
            if(this.PanelContenedor.Controls.Count > 0)
            {
                this.PanelContenedor.Controls.RemoveAt(0);
            }
            Form form = FormHijo as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.PanelContenedor.Controls.Add(form);
            this.PanelContenedor.Tag = form;
            form.Show();
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new Registro_Vehiculo()); // muestra el forms registro vehiculo
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new Salida_Vehiculo()); // muestra el forms para registrar la salida del vehiculo
        }
        //metodo cerrar sesion 
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Cerrar Sesión?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) 
                == DialogResult.Yes) //se muestra un mensaje, si quiere cerrar sesion, si es igual a "si "
                this.Close(); //se cierra sesion
        }

       
        private void Menu_Load(object sender, EventArgs e)
        {
            colorOriginalBtnEntrada = btnEntrada.BackColor;
            var rol = SesionActual.Usuario.NombreRol; //se guarda el nombre del rol en la variable

            if (rol == "Operador") //Se valida que tipo de rol tiene el usuario que inicio sesion para otorgar o no permisos
            {
                btnEstablecerTarifas.Visible = false;
                btnNuevoUsuario.Visible = false;
                btnEspacios.Visible = false;
            }

            if (rol == "Administrador")
            {
                // acceso total
            }

            //Mostrar nombre y posicion en el menu
            if (SesionActual.Usuario != null)
            {
                lblNomUsuario.Text = $"{SesionActual.Usuario.NombreColaborador} {SesionActual.Usuario.ApellidoColaborador}";
                lblPosicion.Text = SesionActual.Usuario.NombreRol;
            }


        }

        private void btnAjustes_Click(object sender, EventArgs e)
        {
            
            MostrarSubMenu(panelConf); //se clickea el boton y se muentra el submenu
        }

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new Registrar_Usuario());
            OcultarSubMenu(); //se oculta submenu
        }

        private void btnEstablecerTarifas_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new EstablecerTarifa());
            OcultarSubMenu(); //se oculta submenu
        }

        private void btnEspacios_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new EspaciosParqueo());
            OcultarSubMenu();//se oculta submenu
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new Reportes());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new Clientes());
        }


        public void ActualizarContador()
        {
            int ocupados = nEntradaVehiculo.ContarVehiculosEnParqueo();
            lblVehiculosDisponibles.Text = $"Espacios ocupados: {ocupados}";
        }


        // Método para actualizar los labels
        public void ActualizarLabels()
        {
            lblVehiculosDisponibles.Text = $" {nEspaciosParqueo.ObtenerEspaciosVehiculosDisponibles()}";
            lblMotosDisponibles.Text = $" {nEspaciosParqueo.ObtenerEspaciosMotosDisponibles()}";
        }

        private void btnVehiculos_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new Vehiculos());
        }

        private void btnMoto_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new Vehiculos());
        }



        //validaciones
        private void ConfigurarToolTips()
        {
            ToolTip toolTip1 = new ToolTip();

            // Configuración 
            toolTip1.AutoPopDelay = 5000;   // tiempo visible en ms
            toolTip1.InitialDelay = 500;    // retraso antes de aparecer
            toolTip1.ReshowDelay = 200;     // retraso entre apariciones
            toolTip1.ShowAlways = true;     // mostrar incluso si el formulario no está activo

            // Asigna ToolTip a controles
            toolTip1.SetToolTip(this.btnMoto, "Vehiculos en parqueo");
            toolTip1.SetToolTip(this.btnVehiculos, "Vehiculos en parqueo");
            toolTip1.SetToolTip(this.btnMinimizar, "Minimizar");
            toolTip1.SetToolTip(this.btnCerrar, "Cerrar");
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {    
            Inicio inicio = new Inicio();
            AbrirFormPanel(inicio); 
        }
    }
}
