
namespace WindowsFormsApp1
{
    partial class Form1
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
            this.Refresh_Button = new System.Windows.Forms.Button();
            this.BackupFile_Button = new System.Windows.Forms.Button();
            this.AddFile_Button = new System.Windows.Forms.Button();
            this.DeletePath_Button = new System.Windows.Forms.Button();
            this.Log_Label = new System.Windows.Forms.Label();
            this.FilePath_textBox = new System.Windows.Forms.TextBox();
            this.FilePath_label = new System.Windows.Forms.Label();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.Log_richTextBox = new System.Windows.Forms.RichTextBox();
            this.btn_browser = new System.Windows.Forms.Button();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.btn_timkiem = new System.Windows.Forms.Button();
            this.btn_log = new System.Windows.Forms.Button();
            this.cbb_filepath = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ckbox_docx = new System.Windows.Forms.CheckBox();
            this.ckbox_pdf = new System.Windows.Forms.CheckBox();
            this.ckbox_txt = new System.Windows.Forms.CheckBox();
            this.ckbox_pptx = new System.Windows.Forms.CheckBox();
            this.ckbox_xlsx = new System.Windows.Forms.CheckBox();
            this.ckbox_rar = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Refresh_Button
            // 
            this.Refresh_Button.BackColor = System.Drawing.SystemColors.Highlight;
            this.Refresh_Button.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Refresh_Button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Refresh_Button.Location = new System.Drawing.Point(12, 151);
            this.Refresh_Button.Name = "Refresh_Button";
            this.Refresh_Button.Size = new System.Drawing.Size(137, 46);
            this.Refresh_Button.TabIndex = 1;
            this.Refresh_Button.Text = "Refresh log";
            this.Refresh_Button.UseVisualStyleBackColor = false;
            this.Refresh_Button.Click += new System.EventHandler(this.Refresh_Button_Click);
            // 
            // BackupFile_Button
            // 
            this.BackupFile_Button.BackColor = System.Drawing.SystemColors.Highlight;
            this.BackupFile_Button.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackupFile_Button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackupFile_Button.Location = new System.Drawing.Point(12, 263);
            this.BackupFile_Button.Name = "BackupFile_Button";
            this.BackupFile_Button.Size = new System.Drawing.Size(137, 51);
            this.BackupFile_Button.TabIndex = 2;
            this.BackupFile_Button.Text = "Backup file";
            this.BackupFile_Button.UseVisualStyleBackColor = false;
            this.BackupFile_Button.Click += new System.EventHandler(this.BackupFile_Button_Click);
            // 
            // AddFile_Button
            // 
            this.AddFile_Button.BackColor = System.Drawing.SystemColors.Highlight;
            this.AddFile_Button.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddFile_Button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AddFile_Button.Location = new System.Drawing.Point(12, 90);
            this.AddFile_Button.Name = "AddFile_Button";
            this.AddFile_Button.Size = new System.Drawing.Size(137, 55);
            this.AddFile_Button.TabIndex = 3;
            this.AddFile_Button.Text = "Add file path";
            this.AddFile_Button.UseVisualStyleBackColor = false;
            this.AddFile_Button.Click += new System.EventHandler(this.AddFile_Button_Click);
            // 
            // DeletePath_Button
            // 
            this.DeletePath_Button.BackColor = System.Drawing.SystemColors.Highlight;
            this.DeletePath_Button.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeletePath_Button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DeletePath_Button.Location = new System.Drawing.Point(12, 203);
            this.DeletePath_Button.Name = "DeletePath_Button";
            this.DeletePath_Button.Size = new System.Drawing.Size(137, 54);
            this.DeletePath_Button.TabIndex = 4;
            this.DeletePath_Button.Text = "Delete file path";
            this.DeletePath_Button.UseVisualStyleBackColor = false;
            this.DeletePath_Button.Click += new System.EventHandler(this.DeletePath_Button_Click);
            // 
            // Log_Label
            // 
            this.Log_Label.AutoSize = true;
            this.Log_Label.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Log_Label.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Log_Label.Location = new System.Drawing.Point(464, 14);
            this.Log_Label.Name = "Log_Label";
            this.Log_Label.Size = new System.Drawing.Size(66, 34);
            this.Log_Label.TabIndex = 5;
            this.Log_Label.Text = "Log";
            this.Log_Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FilePath_textBox
            // 
            this.FilePath_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilePath_textBox.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.FilePath_textBox.Location = new System.Drawing.Point(170, 485);
            this.FilePath_textBox.Multiline = true;
            this.FilePath_textBox.Name = "FilePath_textBox";
            this.FilePath_textBox.Size = new System.Drawing.Size(557, 30);
            this.FilePath_textBox.TabIndex = 6;
            this.FilePath_textBox.Text = "Nhập file path";
            this.FilePath_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FilePath_textBox.TextChanged += new System.EventHandler(this.FilePath_textBox_TextChanged);
            this.FilePath_textBox.Enter += new System.EventHandler(this.FilePath_textBox_Enter);
            this.FilePath_textBox.Leave += new System.EventHandler(this.FilePath_textBox_Leave);
            // 
            // FilePath_label
            // 
            this.FilePath_label.AutoSize = true;
            this.FilePath_label.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilePath_label.ForeColor = System.Drawing.SystemColors.Highlight;
            this.FilePath_label.Location = new System.Drawing.Point(382, 448);
            this.FilePath_label.Name = "FilePath_label";
            this.FilePath_label.Size = new System.Drawing.Size(137, 34);
            this.FilePath_label.TabIndex = 7;
            this.FilePath_label.Text = "File Path";
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.ItemHeight = 16;
            this.listBoxFiles.Location = new System.Drawing.Point(859, 239);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.Size = new System.Drawing.Size(349, 276);
            this.listBoxFiles.TabIndex = 8;
            // 
            // Log_richTextBox
            // 
            this.Log_richTextBox.Location = new System.Drawing.Point(170, 51);
            this.Log_richTextBox.Name = "Log_richTextBox";
            this.Log_richTextBox.ReadOnly = true;
            this.Log_richTextBox.Size = new System.Drawing.Size(652, 383);
            this.Log_richTextBox.TabIndex = 9;
            this.Log_richTextBox.Text = "";
            this.Log_richTextBox.TextChanged += new System.EventHandler(this.Log_richTextBox_TextChanged);
            // 
            // btn_browser
            // 
            this.btn_browser.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_browser.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_browser.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_browser.Location = new System.Drawing.Point(742, 485);
            this.btn_browser.Name = "btn_browser";
            this.btn_browser.Size = new System.Drawing.Size(80, 30);
            this.btn_browser.TabIndex = 10;
            this.btn_browser.Text = "Browser";
            this.btn_browser.UseVisualStyleBackColor = false;
            this.btn_browser.Click += new System.EventHandler(this.btn_browser_Click);
            // 
            // txt_search
            // 
            this.txt_search.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_search.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.txt_search.Location = new System.Drawing.Point(859, 123);
            this.txt_search.Multiline = true;
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(349, 30);
            this.txt_search.TabIndex = 11;
            this.txt_search.Text = "Nhập từ khóa";
            this.txt_search.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
            this.txt_search.Enter += new System.EventHandler(this.txt_search_Enter);
            this.txt_search.Leave += new System.EventHandler(this.txt_search_Leave);
            // 
            // btn_timkiem
            // 
            this.btn_timkiem.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_timkiem.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_timkiem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_timkiem.Location = new System.Drawing.Point(880, 159);
            this.btn_timkiem.Name = "btn_timkiem";
            this.btn_timkiem.Size = new System.Drawing.Size(86, 34);
            this.btn_timkiem.TabIndex = 48;
            this.btn_timkiem.Text = "Search";
            this.btn_timkiem.UseVisualStyleBackColor = false;
            this.btn_timkiem.Click += new System.EventHandler(this.btn_timkiem_Click);
            // 
            // btn_log
            // 
            this.btn_log.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_log.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_log.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_log.Location = new System.Drawing.Point(12, 320);
            this.btn_log.Name = "btn_log";
            this.btn_log.Size = new System.Drawing.Size(137, 51);
            this.btn_log.TabIndex = 49;
            this.btn_log.Text = "Export Log";
            this.btn_log.UseVisualStyleBackColor = false;
            this.btn_log.Click += new System.EventHandler(this.btn_log_Click);
            // 
            // cbb_filepath
            // 
            this.cbb_filepath.FormattingEnabled = true;
            this.cbb_filepath.Location = new System.Drawing.Point(859, 83);
            this.cbb_filepath.Name = "cbb_filepath";
            this.cbb_filepath.Size = new System.Drawing.Size(349, 24);
            this.cbb_filepath.TabIndex = 50;
            this.cbb_filepath.SelectedIndexChanged += new System.EventHandler(this.cbb_filepath_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(855, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 24);
            this.label1.TabIndex = 51;
            this.label1.Text = "Danh sách các filepath đang theo dõi";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(1109, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 34);
            this.button1.TabIndex = 52;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // ckbox_docx
            // 
            this.ckbox_docx.AutoSize = true;
            this.ckbox_docx.Location = new System.Drawing.Point(859, 203);
            this.ckbox_docx.Name = "ckbox_docx";
            this.ckbox_docx.Size = new System.Drawing.Size(61, 20);
            this.ckbox_docx.TabIndex = 53;
            this.ckbox_docx.Text = ".docx";
            this.ckbox_docx.UseVisualStyleBackColor = true;
            // 
            // ckbox_pdf
            // 
            this.ckbox_pdf.AutoSize = true;
            this.ckbox_pdf.Location = new System.Drawing.Point(919, 203);
            this.ckbox_pdf.Name = "ckbox_pdf";
            this.ckbox_pdf.Size = new System.Drawing.Size(51, 20);
            this.ckbox_pdf.TabIndex = 54;
            this.ckbox_pdf.Text = ".pdf";
            this.ckbox_pdf.UseVisualStyleBackColor = true;
            // 
            // ckbox_txt
            // 
            this.ckbox_txt.AutoSize = true;
            this.ckbox_txt.Location = new System.Drawing.Point(1093, 203);
            this.ckbox_txt.Name = "ckbox_txt";
            this.ckbox_txt.Size = new System.Drawing.Size(44, 20);
            this.ckbox_txt.TabIndex = 55;
            this.ckbox_txt.Text = ".txt";
            this.ckbox_txt.UseVisualStyleBackColor = true;
            // 
            // ckbox_pptx
            // 
            this.ckbox_pptx.AutoSize = true;
            this.ckbox_pptx.Location = new System.Drawing.Point(976, 203);
            this.ckbox_pptx.Name = "ckbox_pptx";
            this.ckbox_pptx.Size = new System.Drawing.Size(57, 20);
            this.ckbox_pptx.TabIndex = 56;
            this.ckbox_pptx.Text = ".pptx";
            this.ckbox_pptx.UseVisualStyleBackColor = true;
            // 
            // ckbox_xlsx
            // 
            this.ckbox_xlsx.AutoSize = true;
            this.ckbox_xlsx.Location = new System.Drawing.Point(1141, 203);
            this.ckbox_xlsx.Name = "ckbox_xlsx";
            this.ckbox_xlsx.Size = new System.Drawing.Size(54, 20);
            this.ckbox_xlsx.TabIndex = 57;
            this.ckbox_xlsx.Text = ".xlsx";
            this.ckbox_xlsx.UseVisualStyleBackColor = true;
            // 
            // ckbox_rar
            // 
            this.ckbox_rar.AutoSize = true;
            this.ckbox_rar.Location = new System.Drawing.Point(1039, 203);
            this.ckbox_rar.Name = "ckbox_rar";
            this.ckbox_rar.Size = new System.Drawing.Size(48, 20);
            this.ckbox_rar.TabIndex = 58;
            this.ckbox_rar.Text = ".rar";
            this.ckbox_rar.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 555);
            this.Controls.Add(this.ckbox_rar);
            this.Controls.Add(this.ckbox_xlsx);
            this.Controls.Add(this.ckbox_pptx);
            this.Controls.Add(this.ckbox_txt);
            this.Controls.Add(this.ckbox_pdf);
            this.Controls.Add(this.ckbox_docx);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbb_filepath);
            this.Controls.Add(this.btn_log);
            this.Controls.Add(this.btn_timkiem);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.btn_browser);
            this.Controls.Add(this.Log_richTextBox);
            this.Controls.Add(this.listBoxFiles);
            this.Controls.Add(this.FilePath_label);
            this.Controls.Add(this.FilePath_textBox);
            this.Controls.Add(this.Log_Label);
            this.Controls.Add(this.DeletePath_Button);
            this.Controls.Add(this.AddFile_Button);
            this.Controls.Add(this.BackupFile_Button);
            this.Controls.Add(this.Refresh_Button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Refresh_Button;
        private System.Windows.Forms.Button BackupFile_Button;
        private System.Windows.Forms.Button AddFile_Button;
        private System.Windows.Forms.Button DeletePath_Button;
        private System.Windows.Forms.Label Log_Label;
        private System.Windows.Forms.TextBox FilePath_textBox;
        private System.Windows.Forms.Label FilePath_label;
        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.RichTextBox Log_richTextBox;
        private System.Windows.Forms.Button btn_browser;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Button btn_timkiem;
        private System.Windows.Forms.Button btn_log;
        private System.Windows.Forms.ComboBox cbb_filepath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox ckbox_docx;
        private System.Windows.Forms.CheckBox ckbox_pdf;
        private System.Windows.Forms.CheckBox ckbox_txt;
        private System.Windows.Forms.CheckBox ckbox_pptx;
        private System.Windows.Forms.CheckBox ckbox_xlsx;
        private System.Windows.Forms.CheckBox ckbox_rar;
    }
}

