namespace AsistenciaSys
{
    partial class CaptureForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaptureForm));
            this.PromptLabel = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.Picture = new System.Windows.Forms.PictureBox();
            this.Prompt = new System.Windows.Forms.TextBox();
            this.StatusText = new System.Windows.Forms.TextBox();
            this.StatusLine = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.labelMenssage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // PromptLabel
            // 
            this.PromptLabel.AutoSize = true;
            this.PromptLabel.Location = new System.Drawing.Point(51, 445);
            this.PromptLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.PromptLabel.Name = "PromptLabel";
            this.PromptLabel.Size = new System.Drawing.Size(86, 25);
            this.PromptLabel.TabIndex = 1;
            this.PromptLabel.Text = "Prompt:";
            this.PromptLabel.Visible = false;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(50, 50);
            this.StatusLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(423, 25);
            this.StatusLabel.TabIndex = 3;
            this.StatusLabel.Text = "Coloca 4 veces el mismo dedo en el lector.";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StatusLabel.Visible = false;
            // 
            // Picture
            // 
            this.Picture.BackColor = System.Drawing.SystemColors.Window;
            this.Picture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Picture.Location = new System.Drawing.Point(725, 94);
            this.Picture.Margin = new System.Windows.Forms.Padding(0);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(250, 320);
            this.Picture.TabIndex = 0;
            this.Picture.TabStop = false;
            // 
            // Prompt
            // 
            this.Prompt.Location = new System.Drawing.Point(149, 445);
            this.Prompt.Margin = new System.Windows.Forms.Padding(6);
            this.Prompt.Name = "Prompt";
            this.Prompt.ReadOnly = true;
            this.Prompt.Size = new System.Drawing.Size(408, 31);
            this.Prompt.TabIndex = 2;
            this.Prompt.Visible = false;
            // 
            // StatusText
            // 
            this.StatusText.BackColor = System.Drawing.SystemColors.Window;
            this.StatusText.Location = new System.Drawing.Point(50, 94);
            this.StatusText.Margin = new System.Windows.Forms.Padding(6);
            this.StatusText.Multiline = true;
            this.StatusText.Name = "StatusText";
            this.StatusText.ReadOnly = true;
            this.StatusText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.StatusText.Size = new System.Drawing.Size(643, 327);
            this.StatusText.TabIndex = 4;
            this.StatusText.Visible = false;
            // 
            // StatusLine
            // 
            this.StatusLine.BackColor = System.Drawing.Color.Transparent;
            this.StatusLine.Location = new System.Drawing.Point(51, 511);
            this.StatusLine.Margin = new System.Windows.Forms.Padding(0);
            this.StatusLine.Name = "StatusLine";
            this.StatusLine.Size = new System.Drawing.Size(680, 40);
            this.StatusLine.TabIndex = 5;
            this.StatusLine.Text = "Pendiente:";
            this.StatusLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StatusLine.Visible = false;
            // 
            // CloseButton
            // 
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(725, 433);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(6);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(250, 55);
            this.CloseButton.TabIndex = 6;
            this.CloseButton.Text = "Volver";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // labelMenssage
            // 
            this.labelMenssage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMenssage.AutoSize = true;
            this.labelMenssage.BackColor = System.Drawing.Color.Transparent;
            this.labelMenssage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMenssage.Location = new System.Drawing.Point(720, 62);
            this.labelMenssage.Margin = new System.Windows.Forms.Padding(0);
            this.labelMenssage.Name = "labelMenssage";
            this.labelMenssage.Size = new System.Drawing.Size(108, 26);
            this.labelMenssage.TabIndex = 7;
            this.labelMenssage.Text = "Mensaje:";
            this.labelMenssage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CaptureForm
            // 
            this.AcceptButton = this.CloseButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(1004, 560);
            this.ControlBox = false;
            this.Controls.Add(this.labelMenssage);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.StatusLine);
            this.Controls.Add(this.StatusText);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.Prompt);
            this.Controls.Add(this.PromptLabel);
            this.Controls.Add(this.Picture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CaptureForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Capturar Huella";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CaptureForm_FormClosed);
            this.Load += new System.EventHandler(this.CaptureForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Picture;
        private System.Windows.Forms.TextBox Prompt;
        private System.Windows.Forms.TextBox StatusText;
        private System.Windows.Forms.Label StatusLine;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label PromptLabel;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label labelMenssage;
    }
}