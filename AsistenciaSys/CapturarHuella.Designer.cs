namespace AsistenciaSys
{
    partial class CapturarHuella
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
            this.labelInfo = new System.Windows.Forms.Label();
            this.labelPen = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(615, 643);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(429, 25);
            this.labelInfo.TabIndex = 8;
            this.labelInfo.Text = "Se debe escanear 4 veces la misma huella.";
            // 
            // labelPen
            // 
            this.labelPen.AutoSize = true;
            this.labelPen.Location = new System.Drawing.Point(735, 678);
            this.labelPen.Name = "labelPen";
            this.labelPen.Size = new System.Drawing.Size(164, 25);
            this.labelPen.TabIndex = 9;
            this.labelPen.Text = "Pendiente(s): 4 ";
            // 
            // CapturarHuella
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 846);
            this.Controls.Add(this.labelPen);
            this.Controls.Add(this.labelInfo);
            this.Margin = new System.Windows.Forms.Padding(12);
            this.MinimumSize = new System.Drawing.Size(1522, 917);
            this.Name = "CapturarHuella";
            this.RightToLeftLayout = true;
            this.Text = "Verificar ";
            this.Controls.SetChildIndex(this.labelInfo, 0);
            this.Controls.SetChildIndex(this.labelPen, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label labelPen;
    }
}