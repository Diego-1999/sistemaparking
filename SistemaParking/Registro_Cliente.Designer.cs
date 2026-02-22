namespace SistemaParking
{
    partial class Registro_Cliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.gpbInfoVehiculo = new System.Windows.Forms.GroupBox();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.lblTipoVehiculo = new System.Windows.Forms.Label();
            this.lblPlaca = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.cmbTipoVehiculo = new System.Windows.Forms.ComboBox();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.gpbInfoCliente = new System.Windows.Forms.GroupBox();
            this.mskCedula = new System.Windows.Forms.MaskedTextBox();
            this.cmbTipoIden = new System.Windows.Forms.ComboBox();
            this.lblTipoIdenti = new System.Windows.Forms.Label();
            this.lblCedula = new System.Windows.Forms.Label();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnRegistrarSegundoVehiculo = new System.Windows.Forms.Button();
            this.gpbInfoVehiculo.SuspendLayout();
            this.gpbInfoCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(435, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(196, 30);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Registro de Clientes";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(659, 535);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(185, 40);
            this.btnLimpiar.TabIndex = 13;
            this.btnLimpiar.Text = "Limpiar ";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnRegistrar.FlatAppearance.BorderSize = 0;
            this.btnRegistrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistrar.Location = new System.Drawing.Point(850, 535);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(185, 40);
            this.btnRegistrar.TabIndex = 12;
            this.btnRegistrar.Text = "Registrar Cliente";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // gpbInfoVehiculo
            // 
            this.gpbInfoVehiculo.Controls.Add(this.cmbColor);
            this.gpbInfoVehiculo.Controls.Add(this.cmbMarca);
            this.gpbInfoVehiculo.Controls.Add(this.lblTipoVehiculo);
            this.gpbInfoVehiculo.Controls.Add(this.lblPlaca);
            this.gpbInfoVehiculo.Controls.Add(this.lblColor);
            this.gpbInfoVehiculo.Controls.Add(this.lblMarca);
            this.gpbInfoVehiculo.Controls.Add(this.cmbTipoVehiculo);
            this.gpbInfoVehiculo.Controls.Add(this.txtPlaca);
            this.gpbInfoVehiculo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbInfoVehiculo.Location = new System.Drawing.Point(16, 285);
            this.gpbInfoVehiculo.Name = "gpbInfoVehiculo";
            this.gpbInfoVehiculo.Size = new System.Drawing.Size(1019, 203);
            this.gpbInfoVehiculo.TabIndex = 27;
            this.gpbInfoVehiculo.TabStop = false;
            this.gpbInfoVehiculo.Text = "Información del Vehículo";
            // 
            // cmbColor
            // 
            this.cmbColor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbColor.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Location = new System.Drawing.Point(412, 150);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(181, 33);
            this.cmbColor.TabIndex = 35;
            // 
            // cmbMarca
            // 
            this.cmbMarca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbMarca.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(116, 70);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(181, 33);
            this.cmbMarca.TabIndex = 34;
            // 
            // lblTipoVehiculo
            // 
            this.lblTipoVehiculo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTipoVehiculo.AutoSize = true;
            this.lblTipoVehiculo.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lblTipoVehiculo.Location = new System.Drawing.Point(407, 42);
            this.lblTipoVehiculo.Name = "lblTipoVehiculo";
            this.lblTipoVehiculo.Size = new System.Drawing.Size(153, 25);
            this.lblTipoVehiculo.TabIndex = 33;
            this.lblTipoVehiculo.Text = "Tipo de Vehículo";
            // 
            // lblPlaca
            // 
            this.lblPlaca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPlaca.AutoSize = true;
            this.lblPlaca.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lblPlaca.Location = new System.Drawing.Point(115, 122);
            this.lblPlaca.Name = "lblPlaca";
            this.lblPlaca.Size = new System.Drawing.Size(57, 25);
            this.lblPlaca.TabIndex = 32;
            this.lblPlaca.Text = "Placa";
            // 
            // lblColor
            // 
            this.lblColor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblColor.AutoSize = true;
            this.lblColor.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lblColor.Location = new System.Drawing.Point(407, 122);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(58, 25);
            this.lblColor.TabIndex = 31;
            this.lblColor.Text = "Color";
            // 
            // lblMarca
            // 
            this.lblMarca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lblMarca.Location = new System.Drawing.Point(115, 42);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(174, 25);
            this.lblMarca.TabIndex = 30;
            this.lblMarca.Text = "Marca del Vehiculo";
            // 
            // cmbTipoVehiculo
            // 
            this.cmbTipoVehiculo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbTipoVehiculo.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.cmbTipoVehiculo.FormattingEnabled = true;
            this.cmbTipoVehiculo.Location = new System.Drawing.Point(412, 70);
            this.cmbTipoVehiculo.Name = "cmbTipoVehiculo";
            this.cmbTipoVehiculo.Size = new System.Drawing.Size(181, 33);
            this.cmbTipoVehiculo.TabIndex = 29;
            // 
            // txtPlaca
            // 
            this.txtPlaca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPlaca.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.txtPlaca.Location = new System.Drawing.Point(116, 150);
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(181, 33);
            this.txtPlaca.TabIndex = 28;
            // 
            // gpbInfoCliente
            // 
            this.gpbInfoCliente.Controls.Add(this.mskCedula);
            this.gpbInfoCliente.Controls.Add(this.cmbTipoIden);
            this.gpbInfoCliente.Controls.Add(this.lblTipoIdenti);
            this.gpbInfoCliente.Controls.Add(this.lblCedula);
            this.gpbInfoCliente.Controls.Add(this.lblCorreo);
            this.gpbInfoCliente.Controls.Add(this.lblTelefono);
            this.gpbInfoCliente.Controls.Add(this.lblApellidos);
            this.gpbInfoCliente.Controls.Add(this.lblNombre);
            this.gpbInfoCliente.Controls.Add(this.txtEmail);
            this.gpbInfoCliente.Controls.Add(this.txtTelefono);
            this.gpbInfoCliente.Controls.Add(this.txtApellidos);
            this.gpbInfoCliente.Controls.Add(this.txtNombre);
            this.gpbInfoCliente.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbInfoCliente.Location = new System.Drawing.Point(16, 54);
            this.gpbInfoCliente.Name = "gpbInfoCliente";
            this.gpbInfoCliente.Size = new System.Drawing.Size(1019, 203);
            this.gpbInfoCliente.TabIndex = 28;
            this.gpbInfoCliente.TabStop = false;
            this.gpbInfoCliente.Text = "Información del Cliente";
            // 
            // mskCedula
            // 
            this.mskCedula.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.mskCedula.Location = new System.Drawing.Point(412, 66);
            this.mskCedula.Name = "mskCedula";
            this.mskCedula.Size = new System.Drawing.Size(181, 33);
            this.mskCedula.TabIndex = 52;
            this.mskCedula.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mskCedula_KeyDown);
            // 
            // cmbTipoIden
            // 
            this.cmbTipoIden.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbTipoIden.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.cmbTipoIden.FormattingEnabled = true;
            this.cmbTipoIden.Location = new System.Drawing.Point(61, 60);
            this.cmbTipoIden.Name = "cmbTipoIden";
            this.cmbTipoIden.Size = new System.Drawing.Size(236, 33);
            this.cmbTipoIden.TabIndex = 51;
            this.cmbTipoIden.SelectedIndexChanged += new System.EventHandler(this.cmbTipoIden_SelectedIndexChanged);
            // 
            // lblTipoIdenti
            // 
            this.lblTipoIdenti.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTipoIdenti.AutoSize = true;
            this.lblTipoIdenti.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lblTipoIdenti.Location = new System.Drawing.Point(95, 32);
            this.lblTipoIdenti.Name = "lblTipoIdenti";
            this.lblTipoIdenti.Size = new System.Drawing.Size(194, 25);
            this.lblTipoIdenti.TabIndex = 50;
            this.lblTipoIdenti.Text = "Tipo de Identificación";
            // 
            // lblCedula
            // 
            this.lblCedula.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCedula.AutoSize = true;
            this.lblCedula.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lblCedula.Location = new System.Drawing.Point(416, 32);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(71, 25);
            this.lblCedula.TabIndex = 49;
            this.lblCedula.Text = "Cédula";
            // 
            // lblCorreo
            // 
            this.lblCorreo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lblCorreo.Location = new System.Drawing.Point(715, 115);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(169, 25);
            this.lblCorreo.TabIndex = 47;
            this.lblCorreo.Text = "Correo Electronico";
            // 
            // lblTelefono
            // 
            this.lblTelefono.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lblTelefono.Location = new System.Drawing.Point(715, 32);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(84, 25);
            this.lblTelefono.TabIndex = 46;
            this.lblTelefono.Text = "Telefono";
            // 
            // lblApellidos
            // 
            this.lblApellidos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblApellidos.AutoSize = true;
            this.lblApellidos.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lblApellidos.Location = new System.Drawing.Point(416, 115);
            this.lblApellidos.Name = "lblApellidos";
            this.lblApellidos.Size = new System.Drawing.Size(90, 25);
            this.lblApellidos.TabIndex = 45;
            this.lblApellidos.Text = "Apellidos";
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lblNombre.Location = new System.Drawing.Point(115, 115);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(81, 25);
            this.lblNombre.TabIndex = 44;
            this.lblNombre.Text = "Nombre";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.txtEmail.Location = new System.Drawing.Point(720, 143);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(181, 33);
            this.txtEmail.TabIndex = 43;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.txtTelefono.Location = new System.Drawing.Point(720, 59);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(181, 33);
            this.txtTelefono.TabIndex = 42;
            // 
            // txtApellidos
            // 
            this.txtApellidos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtApellidos.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.txtApellidos.Location = new System.Drawing.Point(412, 138);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(181, 33);
            this.txtApellidos.TabIndex = 41;
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.txtNombre.Location = new System.Drawing.Point(116, 138);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(181, 33);
            this.txtNombre.TabIndex = 40;
            // 
            // btnRegistrarSegundoVehiculo
            // 
            this.btnRegistrarSegundoVehiculo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRegistrarSegundoVehiculo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnRegistrarSegundoVehiculo.FlatAppearance.BorderSize = 0;
            this.btnRegistrarSegundoVehiculo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnRegistrarSegundoVehiculo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarSegundoVehiculo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarSegundoVehiculo.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarSegundoVehiculo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistrarSegundoVehiculo.Location = new System.Drawing.Point(12, 521);
            this.btnRegistrarSegundoVehiculo.Name = "btnRegistrarSegundoVehiculo";
            this.btnRegistrarSegundoVehiculo.Size = new System.Drawing.Size(185, 54);
            this.btnRegistrarSegundoVehiculo.TabIndex = 29;
            this.btnRegistrarSegundoVehiculo.Text = "Registrar segundo Vehiculo";
            this.btnRegistrarSegundoVehiculo.UseVisualStyleBackColor = false;
            this.btnRegistrarSegundoVehiculo.Click += new System.EventHandler(this.btnRegistrarSegundoVehiculo_Click);
            // 
            // Registro_Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1047, 587);
            this.Controls.Add(this.btnRegistrarSegundoVehiculo);
            this.Controls.Add(this.gpbInfoCliente);
            this.Controls.Add(this.gpbInfoVehiculo);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.lblTitulo);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Registro_Cliente";
            this.Text = "Registro_Cliente";
            this.Load += new System.EventHandler(this.Registro_Cliente_Load);
            this.gpbInfoVehiculo.ResumeLayout(false);
            this.gpbInfoVehiculo.PerformLayout();
            this.gpbInfoCliente.ResumeLayout(false);
            this.gpbInfoCliente.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.GroupBox gpbInfoVehiculo;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.Label lblTipoVehiculo;
        private System.Windows.Forms.Label lblPlaca;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.ComboBox cmbTipoVehiculo;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.GroupBox gpbInfoCliente;
        private System.Windows.Forms.ComboBox cmbTipoIden;
        private System.Windows.Forms.Label lblTipoIdenti;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cmbColor;
        private System.Windows.Forms.MaskedTextBox mskCedula;
        private System.Windows.Forms.Button btnRegistrarSegundoVehiculo;
    }
}