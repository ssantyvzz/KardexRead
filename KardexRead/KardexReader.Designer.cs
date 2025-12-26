namespace KardexRead
{
    partial class KardexReader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KardexReader));
            this.btnCargarPdf = new System.Windows.Forms.Button();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.dgvKardex = new System.Windows.Forms.DataGridView();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblCarrera = new System.Windows.Forms.Label();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.lblPromedio = new System.Windows.Forms.Label();
            this.lblCreditosPromovidos = new System.Windows.Forms.Label();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.picLogoUadeo = new System.Windows.Forms.PictureBox();
            this.etqCarrera = new System.Windows.Forms.Label();
            this.etqNombre = new System.Windows.Forms.Label();
            this.lblCreditos = new System.Windows.Forms.Label();
            this.etqAvance = new System.Windows.Forms.Label();
            this.etqPromedio = new System.Windows.Forms.Label();
            this.etqMatricula = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKardex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoUadeo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCargarPdf
            // 
            this.btnCargarPdf.BackColor = System.Drawing.Color.White;
            this.btnCargarPdf.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(23)))), ((int)(((byte)(73)))));
            this.btnCargarPdf.FlatAppearance.BorderSize = 10;
            this.btnCargarPdf.Font = new System.Drawing.Font("Microsoft Tai Le", 20F, System.Drawing.FontStyle.Bold);
            this.btnCargarPdf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCargarPdf.Location = new System.Drawing.Point(622, 12);
            this.btnCargarPdf.Name = "btnCargarPdf";
            this.btnCargarPdf.Size = new System.Drawing.Size(350, 100);
            this.btnCargarPdf.TabIndex = 0;
            this.btnCargarPdf.Text = "Cargar PDF";
            this.btnCargarPdf.UseVisualStyleBackColor = false;
            this.btnCargarPdf.Click += new System.EventHandler(this.btnAgregarPdf_Click);
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.BackColor = System.Drawing.Color.White;
            this.btnExportarExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(23)))), ((int)(((byte)(73)))));
            this.btnExportarExcel.FlatAppearance.BorderSize = 10;
            this.btnExportarExcel.Font = new System.Drawing.Font("Microsoft Tai Le", 20F, System.Drawing.FontStyle.Bold);
            this.btnExportarExcel.Location = new System.Drawing.Point(622, 120);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(350, 100);
            this.btnExportarExcel.TabIndex = 1;
            this.btnExportarExcel.Text = "Exportar Excel";
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // dgvKardex
            // 
            this.dgvKardex.AllowUserToAddRows = false;
            this.dgvKardex.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKardex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKardex.Location = new System.Drawing.Point(12, 349);
            this.dgvKardex.Name = "dgvKardex";
            this.dgvKardex.ReadOnly = true;
            this.dgvKardex.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKardex.Size = new System.Drawing.Size(960, 300);
            this.dgvKardex.TabIndex = 2;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(100, 270);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(0, 24);
            this.lblNombre.TabIndex = 3;
            // 
            // lblCarrera
            // 
            this.lblCarrera.AutoSize = true;
            this.lblCarrera.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblCarrera.Location = new System.Drawing.Point(100, 230);
            this.lblCarrera.Name = "lblCarrera";
            this.lblCarrera.Size = new System.Drawing.Size(0, 24);
            this.lblCarrera.TabIndex = 4;
            // 
            // lblMatricula
            // 
            this.lblMatricula.AutoSize = true;
            this.lblMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatricula.Location = new System.Drawing.Point(100, 310);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(0, 24);
            this.lblMatricula.TabIndex = 5;
            // 
            // lblPromedio
            // 
            this.lblPromedio.AutoSize = true;
            this.lblPromedio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPromedio.Location = new System.Drawing.Point(702, 230);
            this.lblPromedio.Name = "lblPromedio";
            this.lblPromedio.Size = new System.Drawing.Size(0, 24);
            this.lblPromedio.TabIndex = 6;
            // 
            // lblCreditosPromovidos
            // 
            this.lblCreditosPromovidos.AutoSize = true;
            this.lblCreditosPromovidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditosPromovidos.Location = new System.Drawing.Point(702, 270);
            this.lblCreditosPromovidos.Name = "lblCreditosPromovidos";
            this.lblCreditosPromovidos.Size = new System.Drawing.Size(0, 24);
            this.lblCreditosPromovidos.TabIndex = 7;
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.AutoSize = true;
            this.lblPorcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentaje.Location = new System.Drawing.Point(702, 310);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(0, 24);
            this.lblPorcentaje.TabIndex = 8;
            // 
            // picLogoUadeo
            // 
            this.picLogoUadeo.Image = ((System.Drawing.Image)(resources.GetObject("picLogoUadeo.Image")));
            this.picLogoUadeo.Location = new System.Drawing.Point(12, 12);
            this.picLogoUadeo.Name = "picLogoUadeo";
            this.picLogoUadeo.Size = new System.Drawing.Size(555, 215);
            this.picLogoUadeo.TabIndex = 9;
            this.picLogoUadeo.TabStop = false;
            // 
            // etqCarrera
            // 
            this.etqCarrera.AutoSize = true;
            this.etqCarrera.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etqCarrera.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(23)))), ((int)(((byte)(73)))));
            this.etqCarrera.Location = new System.Drawing.Point(15, 230);
            this.etqCarrera.Name = "etqCarrera";
            this.etqCarrera.Size = new System.Drawing.Size(70, 13);
            this.etqCarrera.TabIndex = 10;
            this.etqCarrera.Text = "CARRERA:";
            // 
            // etqNombre
            // 
            this.etqNombre.AutoSize = true;
            this.etqNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etqNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(23)))), ((int)(((byte)(73)))));
            this.etqNombre.Location = new System.Drawing.Point(15, 270);
            this.etqNombre.Name = "etqNombre";
            this.etqNombre.Size = new System.Drawing.Size(64, 13);
            this.etqNombre.TabIndex = 11;
            this.etqNombre.Text = "NOMBRE:";
            // 
            // lblCreditos
            // 
            this.lblCreditos.AutoSize = true;
            this.lblCreditos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(23)))), ((int)(((byte)(73)))));
            this.lblCreditos.Location = new System.Drawing.Point(622, 270);
            this.lblCreditos.Name = "lblCreditos";
            this.lblCreditos.Size = new System.Drawing.Size(74, 13);
            this.lblCreditos.TabIndex = 12;
            this.lblCreditos.Text = "CREDITOS:";
            // 
            // etqAvance
            // 
            this.etqAvance.AutoSize = true;
            this.etqAvance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etqAvance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(23)))), ((int)(((byte)(73)))));
            this.etqAvance.Location = new System.Drawing.Point(622, 310);
            this.etqAvance.Name = "etqAvance";
            this.etqAvance.Size = new System.Drawing.Size(60, 13);
            this.etqAvance.TabIndex = 13;
            this.etqAvance.Text = "AVANCE:";
            // 
            // etqPromedio
            // 
            this.etqPromedio.AutoSize = true;
            this.etqPromedio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etqPromedio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(23)))), ((int)(((byte)(73)))));
            this.etqPromedio.Location = new System.Drawing.Point(622, 230);
            this.etqPromedio.Name = "etqPromedio";
            this.etqPromedio.Size = new System.Drawing.Size(77, 13);
            this.etqPromedio.TabIndex = 14;
            this.etqPromedio.Text = "PROMEDIO:";
            // 
            // etqMatricula
            // 
            this.etqMatricula.AutoSize = true;
            this.etqMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etqMatricula.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(23)))), ((int)(((byte)(73)))));
            this.etqMatricula.Location = new System.Drawing.Point(15, 310);
            this.etqMatricula.Name = "etqMatricula";
            this.etqMatricula.Size = new System.Drawing.Size(82, 13);
            this.etqMatricula.TabIndex = 15;
            this.etqMatricula.Text = "MATRICULA:";
            // 
            // KardexReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.etqMatricula);
            this.Controls.Add(this.etqPromedio);
            this.Controls.Add(this.etqAvance);
            this.Controls.Add(this.lblCreditos);
            this.Controls.Add(this.etqNombre);
            this.Controls.Add(this.etqCarrera);
            this.Controls.Add(this.picLogoUadeo);
            this.Controls.Add(this.dgvKardex);
            this.Controls.Add(this.lblPorcentaje);
            this.Controls.Add(this.lblCreditosPromovidos);
            this.Controls.Add(this.lblPromedio);
            this.Controls.Add(this.lblMatricula);
            this.Controls.Add(this.lblCarrera);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.btnCargarPdf);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "KardexReader";
            this.Text = "Lector Kardex UAdeO";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKardex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoUadeo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCargarPdf;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.DataGridView dgvKardex;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblCarrera;
        private System.Windows.Forms.Label lblMatricula;
        private System.Windows.Forms.Label lblPromedio;
        private System.Windows.Forms.Label lblCreditosPromovidos;
        private System.Windows.Forms.Label lblPorcentaje;
        private System.Windows.Forms.PictureBox picLogoUadeo;
        private System.Windows.Forms.Label etqCarrera;
        private System.Windows.Forms.Label etqNombre;
        private System.Windows.Forms.Label lblCreditos;
        private System.Windows.Forms.Label etqAvance;
        private System.Windows.Forms.Label etqPromedio;
        private System.Windows.Forms.Label etqMatricula;
    }
}

