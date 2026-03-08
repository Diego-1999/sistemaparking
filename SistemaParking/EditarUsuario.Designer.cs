namespace SistemaParking
{
    partial class EditarUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditarUsuario));
            this.btnEditar = new System.Windows.Forms.Button();
            this.gpbInfoUsuario = new System.Windows.Forms.GroupBox();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.gpbInfoCliente = new System.Windows.Forms.GroupBox();
            this.mskcedula = new System.Windows.Forms.MaskedTextBox();
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gpbInfoUsuario.SuspendLayout();
            this.gpbInfoCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(31)))), ((int)(((byte)(59)))));
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(835, 497);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(185, 40);
            this.btnEditar.TabIndex = 56;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // gpbInfoUsuario
            // 
            this.gpbInfoUsuario.BackColor = System.Drawing.Color.Transparent;
            this.gpbInfoUsuario.Controls.Add(this.cmbRol);
            this.gpbInfoUsuario.Controls.Add(this.label1);
            this.gpbInfoUsuario.Controls.Add(this.label2);
            this.gpbInfoUsuario.Controls.Add(this.label3);
            this.gpbInfoUsuario.Controls.Add(this.txtContrasena);
            this.gpbInfoUsuario.Controls.Add(this.txtUsuario);
            this.gpbInfoUsuario.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbInfoUsuario.Location = new System.Drawing.Point(4, 272);
            this.gpbInfoUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.gpbInfoUsuario.Name = "gpbInfoUsuario";
            this.gpbInfoUsuario.Padding = new System.Windows.Forms.Padding(2);
            this.gpbInfoUsuario.Size = new System.Drawing.Size(1019, 203);
            this.gpbInfoUsuario.TabIndex = 59;
            this.gpbInfoUsuario.TabStop = false;
            this.gpbInfoUsuario.Text = "Información del Usuario";
            // 
            // cmbRol
            // 
            this.cmbRol.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbRol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbRol.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Location = new System.Drawing.Point(658, 103);
            this.cmbRol.Margin = new System.Windows.Forms.Padding(2);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(181, 33);
            this.cmbRol.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.label1.Location = new System.Drawing.Point(654, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 25);
            this.label1.TabIndex = 56;
            this.label1.Text = "Rol del usuario";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.label2.Location = new System.Drawing.Point(382, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 25);
            this.label2.TabIndex = 55;
            this.label2.Text = "Contraseña";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.label3.Location = new System.Drawing.Point(117, 76);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 25);
            this.label3.TabIndex = 54;
            this.label3.Text = "Nombre Usuario";
            // 
            // txtContrasena
            // 
            this.txtContrasena.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtContrasena.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.txtContrasena.Location = new System.Drawing.Point(386, 103);
            this.txtContrasena.Margin = new System.Windows.Forms.Padding(2);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(181, 33);
            this.txtContrasena.TabIndex = 8;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.txtUsuario.Location = new System.Drawing.Point(121, 103);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(181, 33);
            this.txtUsuario.TabIndex = 7;
            // 
            // gpbInfoCliente
            // 
            this.gpbInfoCliente.BackColor = System.Drawing.Color.Transparent;
            this.gpbInfoCliente.Controls.Add(this.mskcedula);
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
            this.gpbInfoCliente.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbInfoCliente.Location = new System.Drawing.Point(4, 55);
            this.gpbInfoCliente.Margin = new System.Windows.Forms.Padding(2);
            this.gpbInfoCliente.Name = "gpbInfoCliente";
            this.gpbInfoCliente.Padding = new System.Windows.Forms.Padding(2);
            this.gpbInfoCliente.Size = new System.Drawing.Size(1019, 203);
            this.gpbInfoCliente.TabIndex = 58;
            this.gpbInfoCliente.TabStop = false;
            this.gpbInfoCliente.Text = "Información del Colaborador";
            // 
            // mskcedula
            // 
            this.mskcedula.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.mskcedula.Location = new System.Drawing.Point(373, 77);
            this.mskcedula.Name = "mskcedula";
            this.mskcedula.Size = new System.Drawing.Size(180, 33);
            this.mskcedula.TabIndex = 51;
            // 
            // cmbTipoIden
            // 
            this.cmbTipoIden.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbTipoIden.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbTipoIden.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.cmbTipoIden.FormattingEnabled = true;
            this.cmbTipoIden.Location = new System.Drawing.Point(82, 71);
            this.cmbTipoIden.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTipoIden.Name = "cmbTipoIden";
            this.cmbTipoIden.Size = new System.Drawing.Size(264, 33);
            this.cmbTipoIden.TabIndex = 4;
            // 
            // lblTipoIdenti
            // 
            this.lblTipoIdenti.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTipoIdenti.AutoSize = true;
            this.lblTipoIdenti.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lblTipoIdenti.Location = new System.Drawing.Point(127, 44);
            this.lblTipoIdenti.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
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
            this.lblCedula.Location = new System.Drawing.Point(368, 44);
            this.lblCedula.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
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
            this.lblCorreo.Location = new System.Drawing.Point(654, 120);
            this.lblCorreo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
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
            this.lblTelefono.Location = new System.Drawing.Point(654, 37);
            this.lblTelefono.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
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
            this.lblApellidos.Location = new System.Drawing.Point(368, 125);
            this.lblApellidos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
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
            this.lblNombre.Location = new System.Drawing.Point(127, 120);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(81, 25);
            this.lblNombre.TabIndex = 44;
            this.lblNombre.Text = "Nombre";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.txtEmail.Location = new System.Drawing.Point(658, 147);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(181, 33);
            this.txtEmail.TabIndex = 6;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.txtTelefono.Location = new System.Drawing.Point(658, 64);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(2);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(181, 33);
            this.txtTelefono.TabIndex = 3;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // txtApellidos
            // 
            this.txtApellidos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtApellidos.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.txtApellidos.Location = new System.Drawing.Point(372, 147);
            this.txtApellidos.Margin = new System.Windows.Forms.Padding(2);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(181, 33);
            this.txtApellidos.TabIndex = 2;
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.txtNombre.Location = new System.Drawing.Point(132, 147);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(181, 33);
            this.txtNombre.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.White;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(473, 9);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(169, 28);
            this.lblTitulo.TabIndex = 57;
            this.lblTitulo.Text = "Registro Usuario";
            // 
            // EditarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1031, 548);
            this.Controls.Add(this.gpbInfoUsuario);
            this.Controls.Add(this.gpbInfoCliente);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnEditar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditarUsuario";
            this.Text = "EditarUsuario";
            this.gpbInfoUsuario.ResumeLayout(false);
            this.gpbInfoUsuario.PerformLayout();
            this.gpbInfoCliente.ResumeLayout(false);
            this.gpbInfoCliente.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.GroupBox gpbInfoUsuario;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.GroupBox gpbInfoCliente;
        private System.Windows.Forms.MaskedTextBox mskcedula;
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
        private System.Windows.Forms.Label lblTitulo;
    }
}