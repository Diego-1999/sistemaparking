namespace SistemaParking
{
    partial class Reportes
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
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.gpbFechasreporte = new System.Windows.Forms.GroupBox();
            this.lblFechaFinal = new System.Windows.Forms.Label();
            this.LblFechaInicial = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.gpbFechasreporte.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvReporte
            // 
            this.dgvReporte.AllowUserToOrderColumns = true;
            this.dgvReporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvReporte.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporte.Location = new System.Drawing.Point(12, 136);
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.Size = new System.Drawing.Size(1023, 392);
            this.dgvReporte.TabIndex = 0;
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.dtpFechaInicial.Location = new System.Drawing.Point(132, 44);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(274, 33);
            this.dtpFechaInicial.TabIndex = 1;
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.dtpFechaFinal.Location = new System.Drawing.Point(635, 44);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(274, 33);
            this.dtpFechaFinal.TabIndex = 2;
            // 
            // gpbFechasreporte
            // 
            this.gpbFechasreporte.Controls.Add(this.lblFechaFinal);
            this.gpbFechasreporte.Controls.Add(this.LblFechaInicial);
            this.gpbFechasreporte.Controls.Add(this.dtpFechaInicial);
            this.gpbFechasreporte.Controls.Add(this.dtpFechaFinal);
            this.gpbFechasreporte.Location = new System.Drawing.Point(12, 40);
            this.gpbFechasreporte.Name = "gpbFechasreporte";
            this.gpbFechasreporte.Size = new System.Drawing.Size(1023, 90);
            this.gpbFechasreporte.TabIndex = 3;
            this.gpbFechasreporte.TabStop = false;
            this.gpbFechasreporte.Text = "Fechas Reporte";
            // 
            // lblFechaFinal
            // 
            this.lblFechaFinal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFechaFinal.AutoSize = true;
            this.lblFechaFinal.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lblFechaFinal.Location = new System.Drawing.Point(578, 16);
            this.lblFechaFinal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFechaFinal.Name = "lblFechaFinal";
            this.lblFechaFinal.Size = new System.Drawing.Size(111, 25);
            this.lblFechaFinal.TabIndex = 11;
            this.lblFechaFinal.Text = "Fecha Final ";
            // 
            // LblFechaInicial
            // 
            this.LblFechaInicial.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblFechaInicial.AutoSize = true;
            this.LblFechaInicial.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.LblFechaInicial.Location = new System.Drawing.Point(74, 16);
            this.LblFechaInicial.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblFechaInicial.Name = "LblFechaInicial";
            this.LblFechaInicial.Size = new System.Drawing.Size(121, 25);
            this.LblFechaInicial.TabIndex = 10;
            this.LblFechaInicial.Text = "Fecha Inicial ";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(457, 9);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(94, 30);
            this.lblTitulo.TabIndex = 4;
            this.lblTitulo.Text = "Reportes";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(851, 536);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(185, 40);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1047, 587);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.gpbFechasreporte);
            this.Controls.Add(this.dgvReporte);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Reportes";
            this.Text = "Reportes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.gpbFechasreporte.ResumeLayout(false);
            this.gpbFechasreporte.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReporte;
        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.GroupBox gpbFechasreporte;
        private System.Windows.Forms.Label LblFechaInicial;
        private System.Windows.Forms.Label lblFechaFinal;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnBuscar;
    }
}