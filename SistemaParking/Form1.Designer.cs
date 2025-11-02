namespace SistemaParking
{
    partial class frmMainMenu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainMenu));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnConfiguracion = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnResgitroUsuario = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnSalidaV = new System.Windows.Forms.Button();
            this.btnRegistroV = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.btnConfiguracion);
            this.panelMenu.Controls.Add(this.btnClientes);
            this.panelMenu.Controls.Add(this.btnResgitroUsuario);
            this.panelMenu.Controls.Add(this.btnReportes);
            this.panelMenu.Controls.Add(this.btnSalidaV);
            this.panelMenu.Controls.Add(this.btnRegistroV);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 498);
            this.panelMenu.TabIndex = 0;
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConfiguracion.FlatAppearance.BorderSize = 0;
            this.btnConfiguracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfiguracion.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnConfiguracion.Image = ((System.Drawing.Image)(resources.GetObject("btnConfiguracion.Image")));
            this.btnConfiguracion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfiguracion.Location = new System.Drawing.Point(0, 380);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnConfiguracion.Size = new System.Drawing.Size(220, 60);
            this.btnConfiguracion.TabIndex = 5;
            this.btnConfiguracion.Text = "  Configuración";
            this.btnConfiguracion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfiguracion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfiguracion.UseVisualStyleBackColor = true;
            this.btnConfiguracion.Click += new System.EventHandler(this.btnConfiguracion_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnClientes.Image = ((System.Drawing.Image)(resources.GetObject("btnClientes.Image")));
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.Location = new System.Drawing.Point(0, 320);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnClientes.Size = new System.Drawing.Size(220, 60);
            this.btnClientes.TabIndex = 4;
            this.btnClientes.Text = "  Clientes";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnResgitroUsuario
            // 
            this.btnResgitroUsuario.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnResgitroUsuario.FlatAppearance.BorderSize = 0;
            this.btnResgitroUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResgitroUsuario.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnResgitroUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnResgitroUsuario.Image")));
            this.btnResgitroUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResgitroUsuario.Location = new System.Drawing.Point(0, 260);
            this.btnResgitroUsuario.Name = "btnResgitroUsuario";
            this.btnResgitroUsuario.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnResgitroUsuario.Size = new System.Drawing.Size(220, 60);
            this.btnResgitroUsuario.TabIndex = 3;
            this.btnResgitroUsuario.Text = "  Registrar Nuevo Usuario";
            this.btnResgitroUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResgitroUsuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnResgitroUsuario.UseVisualStyleBackColor = true;
            this.btnResgitroUsuario.Click += new System.EventHandler(this.btnResgitroUsuario_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnReportes.Image = ((System.Drawing.Image)(resources.GetObject("btnReportes.Image")));
            this.btnReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportes.Location = new System.Drawing.Point(0, 200);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnReportes.Size = new System.Drawing.Size(220, 60);
            this.btnReportes.TabIndex = 2;
            this.btnReportes.Text = "  Reportes";
            this.btnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReportes.UseVisualStyleBackColor = true;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnSalidaV
            // 
            this.btnSalidaV.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSalidaV.FlatAppearance.BorderSize = 0;
            this.btnSalidaV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalidaV.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSalidaV.Image = ((System.Drawing.Image)(resources.GetObject("btnSalidaV.Image")));
            this.btnSalidaV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalidaV.Location = new System.Drawing.Point(0, 140);
            this.btnSalidaV.Name = "btnSalidaV";
            this.btnSalidaV.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnSalidaV.Size = new System.Drawing.Size(220, 60);
            this.btnSalidaV.TabIndex = 1;
            this.btnSalidaV.Text = "  Salida de Vehículo";
            this.btnSalidaV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalidaV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalidaV.UseVisualStyleBackColor = true;
            this.btnSalidaV.Click += new System.EventHandler(this.btnSalidaV_Click);
            // 
            // btnRegistroV
            // 
            this.btnRegistroV.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRegistroV.FlatAppearance.BorderSize = 0;
            this.btnRegistroV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistroV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistroV.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnRegistroV.Image = ((System.Drawing.Image)(resources.GetObject("btnRegistroV.Image")));
            this.btnRegistroV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistroV.Location = new System.Drawing.Point(0, 80);
            this.btnRegistroV.Name = "btnRegistroV";
            this.btnRegistroV.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnRegistroV.Size = new System.Drawing.Size(220, 60);
            this.btnRegistroV.TabIndex = 0;
            this.btnRegistroV.Text = "  Ingreso de Vehículo";
            this.btnRegistroV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistroV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRegistroV.UseVisualStyleBackColor = true;
            this.btnRegistroV.Click += new System.EventHandler(this.btnRegistroV_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelLogo.Controls.Add(this.label1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 80);
            this.panelLogo.TabIndex = 0;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.panelTitleBar.Controls.Add(this.lblTitle);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(220, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(616, 80);
            this.panelTitleBar.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Modern No. 20", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(284, 31);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(52, 16);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "INICIO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(21, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "PARQUEO PLAZA DON PEDRO";
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 498);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.Name = "frmMainMenu";
            this.Text = "FormMainMenu";
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnRegistroV;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnConfiguracion;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnResgitroUsuario;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnSalidaV;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
    }
}

