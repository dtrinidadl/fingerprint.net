namespace AsistenciaSys
{
    partial class frmRegistrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistrar));
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnCapturarHuella = new System.Windows.Forms.Button();
            this.dataGridViewStudents = new System.Windows.Forms.DataGridView();
            this.loading = new System.Windows.Forms.ProgressBar();
            this.btnBackPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.labelNoPage = new System.Windows.Forms.Label();
            this.btnReload = new System.Windows.Forms.Button();
            this.labelHuella = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(50, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Estudiante:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Enabled = false;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnGuardar.Location = new System.Drawing.Point(600, 84);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(6);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(250, 50);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar Huella";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardarHuella_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(205, 30);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(6);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(645, 33);
            this.txtNombre.TabIndex = 3;
            this.txtNombre.Text = "Seleccione un estudiante de la tabla...";
            // 
            // btnCapturarHuella
            // 
            this.btnCapturarHuella.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCapturarHuella.Enabled = false;
            this.btnCapturarHuella.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapturarHuella.Location = new System.Drawing.Point(50, 84);
            this.btnCapturarHuella.Margin = new System.Windows.Forms.Padding(6);
            this.btnCapturarHuella.Name = "btnCapturarHuella";
            this.btnCapturarHuella.Size = new System.Drawing.Size(250, 50);
            this.btnCapturarHuella.TabIndex = 5;
            this.btnCapturarHuella.Text = "Capturar Huella";
            this.btnCapturarHuella.UseVisualStyleBackColor = true;
            this.btnCapturarHuella.Click += new System.EventHandler(this.btnCapturarHuella_Click);
            // 
            // dataGridViewStudents
            // 
            this.dataGridViewStudents.AllowUserToAddRows = false;
            this.dataGridViewStudents.AllowUserToDeleteRows = false;
            this.dataGridViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudents.Location = new System.Drawing.Point(50, 149);
            this.dataGridViewStudents.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridViewStudents.Name = "dataGridViewStudents";
            this.dataGridViewStudents.ReadOnly = true;
            this.dataGridViewStudents.RowHeadersVisible = false;
            this.dataGridViewStudents.RowHeadersWidth = 82;
            this.dataGridViewStudents.Size = new System.Drawing.Size(800, 600);
            this.dataGridViewStudents.TabIndex = 6;
            // 
            // loading
            // 
            this.loading.Enabled = false;
            this.loading.Location = new System.Drawing.Point(225, 419);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(450, 60);
            this.loading.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.loading.TabIndex = 7;
            // 
            // btnBackPage
            // 
            this.btnBackPage.Location = new System.Drawing.Point(50, 764);
            this.btnBackPage.Name = "btnBackPage";
            this.btnBackPage.Size = new System.Drawing.Size(80, 44);
            this.btnBackPage.TabIndex = 8;
            this.btnBackPage.Text = "<<";
            this.btnBackPage.UseVisualStyleBackColor = true;
            this.btnBackPage.Click += new System.EventHandler(this.btnBackPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(326, 764);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(80, 44);
            this.btnNextPage.TabIndex = 9;
            this.btnNextPage.Text = ">>";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // labelNoPage
            // 
            this.labelNoPage.AutoSize = true;
            this.labelNoPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoPage.ForeColor = System.Drawing.SystemColors.Control;
            this.labelNoPage.Location = new System.Drawing.Point(168, 777);
            this.labelNoPage.Name = "labelNoPage";
            this.labelNoPage.Size = new System.Drawing.Size(101, 26);
            this.labelNoPage.TabIndex = 11;
            this.labelNoPage.Text = "Pág. 0/0";
            this.labelNoPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(725, 764);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(125, 40);
            this.btnReload.TabIndex = 12;
            this.btnReload.Text = "Recargar";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // labelHuella
            // 
            this.labelHuella.AutoSize = true;
            this.labelHuella.BackColor = System.Drawing.Color.Transparent;
            this.labelHuella.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHuella.ForeColor = System.Drawing.SystemColors.Control;
            this.labelHuella.Location = new System.Drawing.Point(308, 101);
            this.labelHuella.Name = "labelHuella";
            this.labelHuella.Size = new System.Drawing.Size(222, 29);
            this.labelHuella.TabIndex = 13;
            this.labelHuella.Text = "Huella Capturada!";
            this.labelHuella.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.labelHuella.Visible = false;
            // 
            // frmRegistrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(874, 819);
            this.Controls.Add(this.labelHuella);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.labelNoPage);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnBackPage);
            this.Controls.Add(this.loading);
            this.Controls.Add(this.dataGridViewStudents);
            this.Controls.Add(this.btnCapturarHuella);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximumSize = new System.Drawing.Size(900, 890);
            this.MinimumSize = new System.Drawing.Size(900, 890);
            this.Name = "frmRegistrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Estudiantes";
            this.Load += new System.EventHandler(this.frmRegistrar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnCapturarHuella;
        private System.Windows.Forms.DataGridView dataGridViewStudents;
        private System.Windows.Forms.ProgressBar loading;
        private System.Windows.Forms.Button btnBackPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Label labelNoPage;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Label labelHuella;
    }
}