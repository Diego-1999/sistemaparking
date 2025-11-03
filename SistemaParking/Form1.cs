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
    public partial class frmMainMenu : Form
    {
        //Campos
        private Button currentButon;
        private Random random;
        private int tempInddex;
        private Form activeFrom;

        //Constructor
        public frmMainMenu()
        {
            InitializeComponent();
            random = new Random();
        }

        //Metodos
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while(tempInddex == index) //Si el color ya ha sido seleccionado,seleccionamos para elegir uno nuevo
            {
               index= random.Next(ThemeColor.ColorList.Count);
            }
            tempInddex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if(btnSender != null)
            {
                if(currentButon != (Button)btnSender)
                {
                    DisableButon();
                    Color color = SelectThemeColor();
                    currentButon = (Button)btnSender;
                    currentButon.BackColor = color;
                    currentButon.ForeColor = Color.White;
                    currentButon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                }
            }
        }

        private void DisableButon()
        {
            foreach(Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor=Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        //metodo para abrir formularios den el panel contenedor
        public void OpenChildForm(Form childForm, object btnSender)
        {
            if(activeFrom != null)
            {
                activeFrom.Close();
            }
            ActivateButton(btnSender);
            activeFrom = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text; //mostramos el txt del formulario hijo en la barra del lbltitle


        }


        //Eventos
        private void btnRegistroV_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormIngresoVehiculos(), sender);
        }

        private void btnSalidaV_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormSalidaVehiculo(), sender);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormReportes(), sender);
        }

        private void btnResgitroUsuario_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormRegistroNuevoCliente(), sender);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormClientes(), sender);
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormConfiguracion(), sender);
        }

    }
}
