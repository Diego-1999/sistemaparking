using Infraestructura;
using SistemaParking.Entidad;
using SistemaParking.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaParking
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.Dll", EntryPoint = "SendMessage")]


        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            //placeholder
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            // placeholder
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            // placeholder
            if (txtPass.Text == "CONTRASEÑA")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.LightGray;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            //placeholder
            if (txtPass.Text == "")
            {
                txtPass.Text = "CONTRASEÑA";
                txtPass.ForeColor = Color.DimGray;
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Funcion que muestra el icono de error 
        private void mensajeError(string msjs)
        {

            lblErrorMensaje.Text = "    " + msjs;
            lblErrorMensaje.Visible = true;
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "USUARIO")
            {
                if (txtPass.Text != "CONTRASEÑA")
                {
                    // instancia Capa negocio
                    NLogin nlogin = new NLogin();
                    var usuario = nlogin.LoginUser(txtUsuario.Text, txtPass.Text);

                    if (usuario != null)
                    {
                        // Guardar sesión
                        SesionActual.Usuario = usuario;

                        Menu mainMenu = new Menu();
                        mainMenu.Show();
                        mainMenu.FormClosed += CerrarSesion;
                        this.Hide(); // Ocultamos el formulario login
                    }
                    else
                    {
                        mensajeError("Usuario o Contraseña incorrecta, intente de nuevo");
                        txtPass.Text = "CONTRASEÑA";
                        txtPass.Focus();
                    }
                }
                else
                {
                    mensajeError("Ingrese su contraseña");
                }
            }
            else
            {
                mensajeError("Ingrese su usuario");
            }
        }

       
        //metodo Cerrar Sesion
        private void CerrarSesion(object sender,FormClosedEventArgs e)
        {
            //Limpiar sesión 
            SesionActual.Usuario = null;

            //Restaurar UI del login
            txtPass.Text = "CONTRASEÑA";
            txtPass.UseSystemPasswordChar = false;

            txtUsuario.Text = "USUARIO";
            lblErrorMensaje.Visible = false;

            //Mostrar login nuevamente
            this.Show();
            txtUsuario.Focus();
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            ProbarConexionAsync();

        }


        public async Task ProbarConexionAsync()
        {
            HttpClient httpClient = new HttpClient();
            ApiClient apiClient = new ApiClient(httpClient);
            ParkingService service = new ParkingService(apiClient);

            await service.ProcesarDatosAsync();
        }
    }
}
