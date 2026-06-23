namespace SistemaParking
{
    partial class EspaciosParqueo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EspaciosParqueo));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.TxtNumeroEspacios = new System.Windows.Forms.TextBox();
            this.LblNumeroEspacios = new System.Windows.Forms.Label();
            this.LblTipoEspacio = new System.Windows.Forms.Label();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.BtnGuardarEspacio = new System.Windows.Forms.Button();
            this.cmbTipoVehiculo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(521, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(346, 35);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Indicar Espacios del Parqueo";
            // 
            // TxtNumeroEspacios
            // 
            this.TxtNumeroEspacios.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtNumeroEspacios.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.TxtNumeroEspacios.Location = new System.Drawing.Point(385, 302);
            this.TxtNumeroEspacios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtNumeroEspacios.Name = "TxtNumeroEspacios";
            this.TxtNumeroEspacios.Size = new System.Drawing.Size(240, 39);
            this.TxtNumeroEspacios.TabIndex = 3;
            this.TxtNumeroEspacios.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNumeroEspacios_KeyPress);
            // 
            // LblNumeroEspacios
            // 
            this.LblNumeroEspacios.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblNumeroEspacios.AutoSize = true;
            this.LblNumeroEspacios.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.LblNumeroEspacios.Location = new System.Drawing.Point(379, 268);
            this.LblNumeroEspacios.Name = "LblNumeroEspacios";
            this.LblNumeroEspacios.Size = new System.Drawing.Size(205, 32);
            this.LblNumeroEspacios.TabIndex = 9;
            this.LblNumeroEspacios.Text = "Número Espacios ";
            // 
            // LblTipoEspacio
            // 
            this.LblTipoEspacio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblTipoEspacio.AutoSize = true;
            this.LblTipoEspacio.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.LblTipoEspacio.Location = new System.Drawing.Point(773, 268);
            this.LblTipoEspacio.Name = "LblTipoEspacio";
            this.LblTipoEspacio.Size = new System.Drawing.Size(181, 32);
            this.LblTipoEspacio.TabIndex = 10;
            this.LblTipoEspacio.Text = "Tipo de Espacio";
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(149)))), ((int)(((byte)(0)))));
            this.BtnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLimpiar.FlatAppearance.BorderSize = 0;
            this.BtnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLimpiar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLimpiar.ForeColor = System.Drawing.Color.White;
            this.BtnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnLimpiar.Location = new System.Drawing.Point(1135, 660);
            this.BtnLimpiar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(247, 49);
            this.BtnLimpiar.TabIndex = 12;
            this.BtnLimpiar.Text = "Limpiar ";
            this.BtnLimpiar.UseVisualStyleBackColor = false;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // BtnGuardarEspacio
            // 
            this.BtnGuardarEspacio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnGuardarEspacio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(31)))), ((int)(((byte)(59)))));
            this.BtnGuardarEspacio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGuardarEspacio.FlatAppearance.BorderSize = 0;
            this.BtnGuardarEspacio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BtnGuardarEspacio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardarEspacio.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardarEspacio.ForeColor = System.Drawing.Color.White;
            this.BtnGuardarEspacio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuardarEspacio.Location = new System.Drawing.Point(856, 660);
            this.BtnGuardarEspacio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnGuardarEspacio.Name = "BtnGuardarEspacio";
            this.BtnGuardarEspacio.Size = new System.Drawing.Size(247, 49);
            this.BtnGuardarEspacio.TabIndex = 11;
            this.BtnGuardarEspacio.Text = "Guardar Espacios";
            this.BtnGuardarEspacio.UseVisualStyleBackColor = false;
            this.BtnGuardarEspacio.Click += new System.EventHandler(this.BtnGuardarEspacio_Click);
            // 
            // cmbTipoVehiculo
            // 
            this.cmbTipoVehiculo.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.cmbTipoVehiculo.FormattingEnabled = true;
            this.cmbTipoVehiculo.Location = new System.Drawing.Point(780, 314);
            this.cmbTipoVehiculo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbTipoVehiculo.Name = "cmbTipoVehiculo";
            this.cmbTipoVehiculo.Size = new System.Drawing.Size(240, 40);
            this.cmbTipoVehiculo.TabIndex = 13;
            // 
            // EspaciosParqueo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1396, 722);
            this.Controls.Add(this.cmbTipoVehiculo);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.BtnGuardarEspacio);
            this.Controls.Add(this.LblTipoEspacio);
            this.Controls.Add(this.LblNumeroEspacios);
            this.Controls.Add(this.TxtNumeroEspacios);
            this.Controls.Add(this.lblTitulo);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EspaciosParqueo";
            this.Text = "EspaciosParqueo";
            this.Load += new System.EventHandler(this.EspaciosParqueo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox TxtNumeroEspacios;
        private System.Windows.Forms.Label LblNumeroEspacios;
        private System.Windows.Forms.Label LblTipoEspacio;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.Button BtnGuardarEspacio;
        private System.Windows.Forms.ComboBox cmbTipoVehiculo;
    }
}