using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;

namespace WindowsFormsApp1
{
    public partial class Form_Exportlog : Form
    {
        public Form_Exportlog()
        {
            InitializeComponent();
        }

        private void Form_Exportlog_Load(object sender, EventArgs e)
        {

        }

        private void btn_browser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                Description = "Chọn thư mục",
                ShowNewFolderButton = true
            };

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                FilePath_textBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void FilePath_textBox_TextChanged(object sender, EventArgs e)
        {
            {
                if (FilePath_textBox.Text != "" || FilePath_textBox.Text != "Nhập file path")
                {
                    FilePath_textBox.TextAlign = HorizontalAlignment.Left;
                    FilePath_textBox.ForeColor = Color.Black;
                }
            }
        }
        private void FilePath_textBox_Enter(object sender, EventArgs e)
        {
            if (FilePath_textBox.Text == "Nhập file path")
            {
                FilePath_textBox.Text = "";
                FilePath_textBox.TextAlign = HorizontalAlignment.Left;
                FilePath_textBox.ForeColor = Color.Black;
            }
        }
        private void FilePath_textBox_Leave(object sender, EventArgs e)
        {
            {
                if (FilePath_textBox.Text == "")
                {
                    FilePath_textBox.Text = "Nhập file path";
                    FilePath_textBox.TextAlign = HorizontalAlignment.Center;
                    FilePath_textBox.ForeColor = Color.Silver;
                }
            }
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn hủy?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private static void Export_Log_function(string filePath, string content)
        {
            // Lấy thời gian hiện tại
            DateTime now = DateTime.Now;
            content = now + "\n" + content; // thêm thời gian trên đầu file log

            // Tạo tên file từ thời gian hiện tại
            string fileName = $"log_on_{now:dd-MM-yyyy HH-mm}.txt";

            // Kết hợp đường dẫn với tên file
            string logFilePath = Path.Combine(filePath, fileName);

            try
            {
                // Sử dụng File.Create để tạo file mới
                using (FileStream fs = File.Create(logFilePath))
                {
                    // Chuyển nội dung thành mảng byte
                    byte[] info = new UTF8Encoding(true).GetBytes(content);

                    // Ghi mảng byte vào file
                    fs.Write(info, 0, info.Length);
                }
                MessageBox.Show($"Log được tạo tại:\n" + logFilePath, "Tạo log");
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
            }
        }
        bool check_filePath(string filePath)
        {
            if (Path.IsPathRooted(filePath))
            {
                return true;
                //Đường dẫn là đường dẫn tuyệt đối, xài đc
            }
            else
            {
                return false;
                //Đường dẫn không phải là đường dẫn tuyệt đối, xài ko đc
            }
        }
        private void btn_ok_Click(object sender, EventArgs e)
        {
            string Log_Data = Form1.Send_Log_Data;
            if (Log_Data == "")
            {
                MessageBox.Show("Chưa có log", "Lỗi");
            }
            else
            {
                if (!string.IsNullOrEmpty(FilePath_textBox.Text))
                {
                    if (check_filePath(FilePath_textBox.Text) == true)
                    {
                        Export_Log_function(FilePath_textBox.Text, Log_Data);
                        this.Close();
                    }
                }
                else
                    MessageBox.Show($"Đường dẫn rỗng, không thể xuất log");
            }
        }

        private void Form_Exportlog_FormClosed(object sender, FormClosedEventArgs e)
        {
            //DialogResult r;
            //r = MessageBox.Show("Bạn có muốn thoát?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            //if (r == DialogResult.Yes)
            //{
            //    this.Close();
            //}
        }

    }
}
