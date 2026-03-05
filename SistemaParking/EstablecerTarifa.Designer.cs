namespace SistemaParking
{
    partial class EstablecerTarifa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EstablecerTarifa));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblFraccionMinuto = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblTipoVehiculo = new System.Windows.Forms.Label();
            this.lblMontoPorHora = new System.Windows.Forms.Label();
            this.txtMontoHora = new System.Windows.Forms.TextBox();
            this.cmbTipoVehiculo = new System.Windows.Forms.ComboBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtFranccionMinuto = new System.Windows.Forms.TextBox();
            this.txtMontoFranccionMinuto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.White;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(435, 18);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(175, 28);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Establecer Tarifa ";
            // 
            // lblFraccionMinuto
            // 
            this.lblFraccionMinuto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFraccionMinuto.AutoSize = true;
            this.lblFraccionMinuto.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lblFraccionMinuto.Location = new System.Drawing.Point(688, 126);
            this.lblFraccionMinuto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFraccionMinuto.Name = "lblFraccionMinuto";
            this.lblFraccionMinuto.Size = new System.Drawing.Size(0, 25);
            this.lblFraccionMinuto.TabIndex = 48;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(149)))), ((int)(((byte)(0)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(851, 536);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(185, 40);
            this.btnLimpiar.TabIndex = 57;
            this.btnLimpiar.Text = "Limpiar ";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(31)))), ((int)(((byte)(59)))));
            this.BtnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGuardar.FlatAppearance.BorderSize = 0;
            this.BtnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.Color.White;
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuardar.Location = new System.Drawing.Point(646, 536);
            this.BtnGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(185, 40);
            this.BtnGuardar.TabIndex = 56;
            this.BtnGuardar.Text = "Guardar Tarifa";
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.txtDescripcion.Location = new System.Drawing.Point(276, 153);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(206, 33);
            this.txtDescripcion.TabIndex = 41;
            // 
            // lblTipoVehiculo
            // 
            this.lblTipoVehiculo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTipoVehiculo.AutoSize = true;
            this.lblTipoVehiculo.BackColor = System.Drawing.Color.White;
            this.lblTipoVehiculo.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lblTipoVehiculo.Location = new System.Drawing.Point(271, 291);
            this.lblTipoVehiculo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTipoVehiculo.Name = "lblTipoVehiculo";
            this.lblTipoVehiculo.Size = new System.Drawing.Size(153, 25);
            this.lblTipoVehiculo.TabIndex = 55;
            this.lblTipoVehiculo.Text = "Tipo de Vehículo";
            // 
            // lblMontoPorHora
            // 
            this.lblMontoPorHora.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMontoPorHora.AutoSize = true;
            this.lblMontoPorHora.BackColor = System.Drawing.Color.White;
            this.lblMontoPorHora.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lblMontoPorHora.Location = new System.Drawing.Point(271, 207);
            this.lblMontoPorHora.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMontoPorHora.Name = "lblMontoPorHora";
            this.lblMontoPorHora.Size = new System.Drawing.Size(146, 25);
            this.lblMontoPorHora.TabIndex = 46;
            this.lblMontoPorHora.Text = "Monto por hora";
            // 
            // txtMontoHora
            // 
            this.txtMontoHora.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMontoHora.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.txtMontoHora.Location = new System.Drawing.Point(276, 234);
            this.txtMontoHora.Margin = new System.Windows.Forms.Padding(2);
            this.txtMontoHora.Name = "txtMontoHora";
            this.txtMontoHora.Size = new System.Drawing.Size(206, 33);
            this.txtMontoHora.TabIndex = 47;
            // 
            // cmbTipoVehiculo
            // 
            this.cmbTipoVehiculo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbTipoVehiculo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbTipoVehiculo.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.cmbTipoVehiculo.FormattingEnabled = true;
            this.cmbTipoVehiculo.Location = new System.Drawing.Point(276, 318);
            this.cmbTipoVehiculo.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTipoVehiculo.Name = "cmbTipoVehiculo";
            this.cmbTipoVehiculo.Size = new System.Drawing.Size(206, 33);
            this.cmbTipoVehiculo.TabIndex = 53;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.BackColor = System.Drawing.Color.White;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lblDescripcion.Location = new System.Drawing.Point(271, 126);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(213, 25);
            this.lblDescripcion.TabIndex = 45;
            this.lblDescripcion.Text = "Descripción del la Tarifa";
            // 
            // txtFranccionMinuto
            // 
            this.txtFranccionMinuto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFranccionMinuto.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.txtFranccionMinuto.Location = new System.Drawing.Point(591, 153);
            this.txtFranccionMinuto.Margin = new System.Windows.Forms.Padding(2);
            this.txtFranccionMinuto.Multiline = true;
            this.txtFranccionMinuto.Name = "txtFranccionMinuto";
            this.txtFranccionMinuto.Size = new System.Drawing.Size(206, 33);
            this.txtFranccionMinuto.TabIndex = 58;
            // 
            // txtMontoFranccionMinuto
            // 
            this.txtMontoFranccionMinuto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMontoFranccionMinuto.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.txtMontoFranccionMinuto.Location = new System.Drawing.Point(591, 234);
            this.txtMontoFranccionMinuto.Margin = new System.Windows.Forms.Padding(2);
            this.txtMontoFranccionMinuto.Multiline = true;
            this.txtMontoFranccionMinuto.Name = "txtMontoFranccionMinuto";
            this.txtMontoFranccionMinuto.Size = new System.Drawing.Size(206, 33);
            this.txtMontoFranccionMinuto.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.label1.Location = new System.Drawing.Point(586, 126);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 25);
            this.label1.TabIndex = 60;
            this.label1.Text = "Fraccion de Minuto";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.label2.Location = new System.Drawing.Point(586, 207);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 25);
            this.label2.TabIndex = 61;
            this.label2.Text = "Monto Franccion Minuto";
            // 
            // EstablecerTarifa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1047, 587);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMontoFranccionMinuto);
            this.Controls.Add(this.txtFranccionMinuto);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.lblTipoVehiculo);
            this.Controls.Add(this.cmbTipoVehiculo);
            this.Controls.Add(this.lblFraccionMinuto);
            this.Controls.Add(this.txtMontoHora);
            this.Controls.Add(this.lblMontoPorHora);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblTitulo);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EstablecerTarifa";
            this.Text = "EstablecerTarifa";
            this.Load += new System.EventHandler(this.EstablecerTarifa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFraccionMinuto;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblTipoVehiculo;
        private System.Windows.Forms.Label lblMontoPorHora;
        private System.Windows.Forms.TextBox txtMontoHora;
        private System.Windows.Forms.ComboBox cmbTipoVehiculo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtFranccionMinuto;
        private System.Windows.Forms.TextBox txtMontoFranccionMinuto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}