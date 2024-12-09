namespace WindowsFormsApp1
{
    partial class Form_Exportlog
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
            this.label1 = new System.Windows.Forms.Label();
            this.FilePath_textBox = new System.Windows.Forms.TextBox();
            this.btn_browser = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(121, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(548, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập đường dẫn file log phía dưới :";
            // 
            // FilePath_textBox
            // 
            this.FilePath_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilePath_textBox.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.FilePath_textBox.Location = new System.Drawing.Point(48, 200);
            this.FilePath_textBox.Multiline = true;
            this.FilePath_textBox.Name = "FilePath_textBox";
            this.FilePath_textBox.Size = new System.Drawing.Size(557, 30);
            this.FilePath_textBox.TabIndex = 7;
            this.FilePath_textBox.Text = "Nhập file path";
            this.FilePath_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FilePath_textBox.TextChanged += new System.EventHandler(this.FilePath_textBox_TextChanged);
            this.FilePath_textBox.Enter += new System.EventHandler(this.FilePath_textBox_Enter);
            this.FilePath_textBox.Leave += new System.EventHandler(this.FilePath_textBox_Leave);
            // 
            // btn_browser
            // 
            this.btn_browser.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_browser.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_browser.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_browser.Location = new System.Drawing.Point(626, 200);
            this.btn_browser.Name = "btn_browser";
            this.btn_browser.Size = new System.Drawing.Size(96, 37);
            this.btn_browser.TabIndex = 11;
            this.btn_browser.Text = "Browse";
            this.btn_browser.UseVisualStyleBackColor = false;
            this.btn_browser.Click += new System.EventHandler(this.btn_browser_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_ok.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ok.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_ok.Location = new System.Drawing.Point(168, 297);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(96, 44);
            this.btn_ok.TabIndex = 12;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancle
            // 
            this.btn_cancle.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_cancle.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancle.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_cancle.Location = new System.Drawing.Point(487, 297);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(96, 44);
            this.btn_cancle.TabIndex = 13;
            this.btn_cancle.Text = "Cancel";
            this.btn_cancle.UseVisualStyleBackColor = false;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // Form_Exportlog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_cancle);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_browser);
            this.Controls.Add(this.FilePath_textBox);
            this.Controls.Add(this.label1);
            this.Name = "Form_Exportlog";
            this.Text = "Xuất Log";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Exportlog_FormClosed);
            this.Load += new System.EventHandler(this.Form_Exportlog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FilePath_textBox;
        private System.Windows.Forms.Button btn_browser;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancle;
    }
}