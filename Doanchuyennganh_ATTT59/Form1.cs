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
using Microsoft.Win32;
using System.Deployment.Application;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //tao bien watcher
        FileSystemWatcher[] watcher = null;
        int num = 1;
        string filePath;
        public static Form1 fm1;
        public static Form_Exportlog fm2;
        private NotifyIcon notifyIcon;

        public Form1()
        {
            InitializeComponent();
            InitializeFileWatcher();
            RegisterToStartUp();

            this.Load += Form1_Load;

            // Khởi tạo NotifyIcon
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = new Icon(@"D:\Study\TienAnThatNghiep\eye_icon-icons.com_71204.ico"); // Đường dẫn tới icon 
            notifyIcon.Visible = true;
            notifyIcon.Text = "File Management";

            // Thêm menu chuột phải vào NotifyIcon
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Mở", null, (s, e) => this.Show()); // Mở form chính
            contextMenu.Items.Add("Thoát", null, (s, e) => Application.Exit()); // Thoát ứng dụng

            notifyIcon.ContextMenuStrip = contextMenu;

            // Đăng ký sự kiện nhấp đúp để mở lại form
            notifyIcon.DoubleClick += (s, e) => this.Show();
        }

        public string Log_Data { get; private set; }
        
        private void InitializeFileWatcher()
        {
            try 
            {
                watcher = new FileSystemWatcher[10];
                for (int i = 0; i < 10; i++)
                {
                    watcher[i] = new FileSystemWatcher();
                    watcher[i].IncludeSubdirectories = true;

                    watcher[i].NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.Size;
                    watcher[i].Filter = "*.*";

                    watcher[i].Created += OnCreated;
                    //watcher[i].Changed += OnChanged;
                    watcher[i].Deleted += OnDeleted;
                    watcher[i].Renamed += OnRenamed;
                }     
            }
            catch (Exception ex) { MessageBox.Show($"Lỗi : {ex.Message}", "Lỗi"); }
        }

        //////////  START UP WITH WINDOWS
        private static void RegisterToStartUp()
        {
            try
            {
                string appName = "File_Monitor"; // Tên ứng dụng cho key
                string appPath = System.Reflection.Assembly.GetExecutingAssembly().Location;

                // Truy cập vào registry của Windows để thêm thông tin tự động khởi động
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

                if (key.GetValue(appName) == null)
                {
                    // Thêm khóa nếu chưa có
                    key.SetValue(appName, appPath);
                    MessageBox.Show("Ứng dụng đã được đăng ký để tự động khởi động cùng Windows.", "START UP WITH WINDOWS");
                }
            }
            catch (Exception ex) { MessageBox.Show($"Lỗi : {ex.Message}", "Lỗi"); }
        }

        //function update filelist listbox
        private void UpdateFileList(string path, FileSystemEventArgs e)
        {
            listBoxFiles.Items.Clear();
            DisplayDirectoryContents(path, 0);
        }
        private void DisplayDirectoryContents(string path, int level)
        {
            var directories = Directory.GetDirectories(path);
            foreach (var directory in directories)
            {
                string indent = new string(' ', level * 4);
                listBoxFiles.Items.Add($"{indent}[Folder] {Path.GetFileName(directory)}");

                DisplayDirectoryContents(directory, level + 1);
            }

            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                string indent = new string(' ', level * 4);
                listBoxFiles.Items.Add($"{indent}[File] {Path.GetFileName(file)}");
            }
        }

        //function onchange
        //private void OnChanged(object sender, FileSystemEventArgs e)
        //{
        //    this.Invoke((MethodInvoker)delegate
        //    {
        //        Log_richTextBox.Text += $" - [{DateTime.Now.ToLocalTime()}] {e.FullPath} \n {e.Name} đã thay đổi \n";
        //        UpdateFileList(watcher.Path, e);
        //    });
        //}
        string filename1,filename2,filepath;
        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {

                filename2 = Path.GetFileName(e.FullPath);
                if (filename2 == filename1)
                {
                    Log_richTextBox.Text += $" - [{DateTime.Now.ToLocalTime()}] {e.FullPath}\n<<<{e.Name}>>> được chuyển từ <<<{filepath}>>> ====> <<<{e.FullPath}>>> \n ";
                }
                else Log_richTextBox.Text += $" - [{DateTime.Now.ToLocalTime()}] {e.FullPath}\n<<<{e.Name}>>> được tạo \n";
                filename1 = null;   
                filename2 = null;   
                filepath = null;
                //UpdateFileList(watcher.Path, e);
            });
        }
        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                filename1 = Path.GetFileName(e.FullPath);
                filepath = e.FullPath;
                string fileName1 = Path.GetFileName(e.FullPath);
                Log_richTextBox.Text += $" - [{DateTime.Now.ToLocalTime()}] {e.FullPath} \n <<<{{{e.Name}}}>>> bị xóa \n";
                //UpdateFileList(watcher.Path, e);
            });
        }
        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                Log_richTextBox.Text += $" - [{DateTime.Now.ToLocalTime()}] {e.FullPath}\n <<<{{{e.OldName}}}>>> đổi tên thành <<<{{{e.Name}}}>>> \n";
                //UpdateFileList(watcher.Path, e);
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void AddFile_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (watcher == null)
                    InitializeFileWatcher();

                string path = FilePath_textBox.Text;

                if (path == "" || path == "Nhập file path")
                    MessageBox.Show("File path trống", "Lỗi");
                else if (Directory.Exists(path))
                {
                    if (num == 1)
                    {
                        watcher[num - 1].Path = path;
                        watcher[num - 1].EnableRaisingEvents = true;
                        num++;
                    }
                    else
                    {
                        num++;
                        watcher[num - 1].Path = path;
                        watcher[num - 1].EnableRaisingEvents = true;
                    }

                    MessageBox.Show("Đang theo dõi: " + path, "Add file path");
                    //UpdateFileList(path, null);

                    cbb_filepath.Items.Add(path);

                    path = null;
                }
                else
                {
                    MessageBox.Show("Thư mục không tồn tại!", "Lỗi");
                }
            }
            catch (Exception ex) { MessageBox.Show($"Lỗi : {ex.Message}", "Lỗi"); }

        }

        private void Refresh_Button_Click(object sender, EventArgs e)
        {
            try
            {
                Log_richTextBox.Text = null;
                MessageBox.Show("Refresh thành công! ", "Refresh");
            }
            catch (Exception ex) { MessageBox.Show($"Lỗi : {ex.Message}", "Lỗi"); }
        }

        private void DeletePath_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (num == 1)
                {
                    MessageBox.Show("Hiện chưa theo dõi đường dẫn nào!", "Lỗi");
                }
                else
                {
                    string deleted_path = FilePath_textBox.Text;
                    if (deleted_path != null)
                    {
                        DialogResult r;
                        r = MessageBox.Show("Bạn có chắc muốn hủy theo dõi " + FilePath_textBox.Text + "?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (r == DialogResult.Yes)
                        {
                            listBoxFiles.Items.Clear();

                            cbb_filepath.Items.Remove(deleted_path);
                            cbb_filepath.Text = null;

                            FilePath_textBox.Text = null;

                            int index = 0;
                            for (int i = 0; i < num; i++)
                            {
                                if (watcher[i].Path == deleted_path)
                                {
                                    index = i;
                                    break;
                                }
                            }
                            watcher[index].EnableRaisingEvents = false;
                            watcher[index].Dispose();

                            MessageBox.Show("Ngừng theo dõi: " + deleted_path, "DeletePath ");
                        }
                    }
                    else { MessageBox.Show("Vui lòng nhập đường dẫn"); } 
                }
            }
            catch (Exception ex) { MessageBox.Show($"Lỗi : {ex.Message}", "Lỗi"); }
        }

        private void Log_richTextBox_TextChanged(object sender, EventArgs e)
        {
            Log_Data = Log_richTextBox.Text;
            string path = cbb_filepath.Text;
            if ( path != "" )
                UpdateFileList(path, null);
        }

        private void BackupFile_Button_Click(object sender, EventArgs e)
        {

        }

        private void btn_browser_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex) { MessageBox.Show($"Lỗi : {ex.Message}", "Lỗi"); }
        }
        public static bool ContainsSubstring(string target, string searchTerm)
        {
            if (target == null || searchTerm == null)
            {
                throw new ArgumentNullException("Chuỗi không được null");
            }

            // Kiểm tra xem chuỗi tìm kiếm có tồn tại trong chuỗi mục tiêu (không phân biệt hoa thường)
            return target.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (cbb_filepath.Items.Count == 0)
                    MessageBox.Show("Chưa có nhập filepath", "Lỗi");
                else
                //&& ckbox_docx.Checked == false && ckbox_pdf.Checked == false && ckbox_pptx.Checked == false && ckbox_rar.Checked == false && ckbox_txt.Checked == false && ckbox_xlsx.Checked == false
                //if (txt_search.Text == "")
                //    MessageBox.Show("Thanh tìm kiếm trống!", "Lỗi");
                //else
                if (cbb_filepath.Text == "")
                    MessageBox.Show("Chưa chọn đường dẫn!", "Lỗi");
                else
                {
                //int i = listBoxFiles.Items.Count;
                //while (i != 0)
                //{
                //    if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), "Folder") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), "folder") == true) { i--; }
                //    else
                //        if (ckbox_docx.Checked && ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".docx") == true) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), txt_search.Text.ToLower()) == true) i--; }
                //    else if (ckbox_docx.Checked && ckbox_pdf.Checked) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".docx") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".pdf") == true) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), txt_search.Text.ToLower()) == true) i--; } }
                //    else if (ckbox_docx.Checked && ckbox_pdf.Checked && ckbox_pptx.Checked) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".docx") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".pdf") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".pptx") == true) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), txt_search.Text.ToLower()) == true) i--; } }
                //    else if (ckbox_docx.Checked && ckbox_pdf.Checked && ckbox_pptx.Checked && ckbox_rar.Checked) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".docx") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".pdf") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".pptx") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".rar") == true) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), txt_search.Text.ToLower()) == true) i--; } }
                //    else if (ckbox_docx.Checked && ckbox_pdf.Checked && ckbox_pptx.Checked && ckbox_rar.Checked && ckbox_txt.Checked) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".docx") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".pdf") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".pptx") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".rar") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".txt") == true) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), txt_search.Text.ToLower()) == true) i--; } }
                //    else if (ckbox_docx.Checked && ckbox_pdf.Checked && ckbox_pptx.Checked && ckbox_rar.Checked && ckbox_txt.Checked && ckbox_xlsx.Checked) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".docx") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".pdf") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".pptx") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".rar") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".txt") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".xlsx") == true) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), txt_search.Text.ToLower()) == true) i--; } }
                //    else
                //    if (ckbox_pdf.Checked && ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".pdf") == true) { i--; }
                //    else if (ckbox_pdf.Checked && ckbox_pptx.Checked) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".pdf") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".pptx") == true) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), txt_search.Text.ToLower()) == true) i--; } }
                //    else if (ckbox_pdf.Checked && ckbox_pptx.Checked && ckbox_rar.Checked) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".pdf") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".pptx") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".rar") == true) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), txt_search.Text.ToLower()) == true) i--; } }
                //    else if (ckbox_pdf.Checked && ckbox_pptx.Checked && ckbox_rar.Checked && ckbox_txt.Checked) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".pdf") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".pptx") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".rar") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".txt") == true) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), txt_search.Text.ToLower()) == true) i--; } }
                //    else if (ckbox_pdf.Checked && ckbox_pptx.Checked && ckbox_rar.Checked && ckbox_txt.Checked && ckbox_xlsx.Checked) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".pdf") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".pptx") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".rar") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".txt") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".xlsx") == true) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), txt_search.Text.ToLower()) == true) i--; } }
                //    else
                //    if (ckbox_pptx.Checked && ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".pptx") == true) { i--; }
                //    else if (ckbox_pptx.Checked && ckbox_rar.Checked) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".pptx") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".rar") == true) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), txt_search.Text.ToLower()) == true) i--; } }
                //    else if (ckbox_pptx.Checked && ckbox_rar.Checked && ckbox_txt.Checked) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".pptx") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".rar") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".txt") == true) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), txt_search.Text.ToLower()) == true) i--; } }
                //    else if (ckbox_pptx.Checked && ckbox_rar.Checked && ckbox_txt.Checked && ckbox_xlsx.Checked) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".pptx") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".rar") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".txt") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".xlsx") == true) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), txt_search.Text.ToLower()) == true) i--; } }
                //    else
                //    if (ckbox_rar.Checked && ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".rar") == true) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), txt_search.Text.ToLower()) == true) i--; }
                //    else if (ckbox_rar.Checked && ckbox_txt.Checked) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".rar") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".txt") == true) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), txt_search.Text.ToLower()) == true) i--; } }
                //    else if (ckbox_rar.Checked && ckbox_txt.Checked && ckbox_xlsx.Checked) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".rar") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".txt") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".xlsx") == true) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), txt_search.Text.ToLower()) == true) i--; } }
                //    else
                //    if (ckbox_txt.Checked && ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".txt") == true) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), txt_search.Text.ToLower()) == true) i--; }
                //    else if (ckbox_txt.Checked && ckbox_xlsx.Checked) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".txt") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".xlsx") == true) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), txt_search.Text.ToLower()) == true) i--; } }
                //    else
                //    if (ckbox_xlsx.Checked && ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), ".xlsx") == true) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString().ToLower(), txt_search.Text.ToLower()) == true) i--; }
                //    else if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), txt_search.Text) == false)
                //    {
                //        listBoxFiles.Items.RemoveAt(i - 1);
                //        i--;
                //    }
                //    //else i--;
                //}

                int i = listBoxFiles.Items.Count;
                while (i != 0)
                {
                    if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), "Folder") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), "folder") == true) { i--; }
                    else
                    if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), txt_search.Text) == false)
                    {
                        listBoxFiles.Items.RemoveAt(i - 1);
                        i--;
                    }
                    else i--;
                }
            }
            //}
            //catch (Exception ex) { MessageBox.Show($"Lỗi : {ex.Message}", "Lỗi"); }
        }
       
        private void btn_log_Click(object sender, EventArgs e)
        {
            try
            {
                fm2 = new Form_Exportlog();
                fm2.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show($"Lỗi : {ex.Message}", "Lỗi"); }
        }

        private void cbb_filepath_SelectedIndexChanged(object sender, EventArgs e)
        {
            string path = cbb_filepath.Text;
            UpdateFileList(path, null);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
            {
                fm1 = new Form1();
                fm1.Close();
            }
        }
        private void btn_refresh_Click(object sender, EventArgs e)
        {  
            try
            {
                if (cbb_filepath.Items.Count == 0)
                    MessageBox.Show("Chưa có nhập filepath", "Lỗi");
                else
                {
                    if (cbb_filepath.Text == "")
                    {
                        MessageBox.Show("Chưa có chọn filepath", "Lỗi");
                    }
                    else
                    {
                        string path = cbb_filepath.Text;

                        if (path == null)
                        {
                            listBoxFiles.Items.Clear();
                        }
                        else
                        {
                            UpdateFileList(path, null);
                            ckbox_docx.Checked = false;
                            ckbox_pdf.Checked = false;
                            ckbox_pptx.Checked = false;
                            ckbox_rar.Checked = false;
                            ckbox_txt.Checked = false;
                            ckbox_xlsx.Checked = false; 
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Lỗi : {ex.Message}", "Lỗi"); }
        }

        //FilePath_textBox
        private void FilePath_textBox_Enter(object sender, EventArgs e)
        {
            if(FilePath_textBox.Text == "Nhập file path")
            {
                FilePath_textBox.Text = "";
                FilePath_textBox.TextAlign = HorizontalAlignment.Left;
                FilePath_textBox.ForeColor = Color.Black;
            }
            
        }
        private void FilePath_textBox_TextChanged(object sender, EventArgs e)
        {
            if(FilePath_textBox.Text != "" || FilePath_textBox.Text != "Nhập file path")
            {
                FilePath_textBox.TextAlign = HorizontalAlignment.Left;
                FilePath_textBox.ForeColor = Color.Black;
            }       
        }
        private void FilePath_textBox_Leave(object sender, EventArgs e)
        {
            if (FilePath_textBox.Text == "")
            {
                FilePath_textBox.Text = "Nhập file path";
                FilePath_textBox.TextAlign = HorizontalAlignment.Center;
                FilePath_textBox.ForeColor = Color.Silver;
            }
            
        }
        //txt_search
        private void txt_search_Enter(object sender, EventArgs e)
        {
            //if (txt_search.Text == "Nhập từ khóa")
            //{
            //    txt_search.Text = "";
            //    txt_search.TextAlign = HorizontalAlignment.Left;
            //    txt_search.ForeColor = Color.Black;
            //}
        }
        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            //txt_search.TextAlign = HorizontalAlignment.Left;
            //txt_search.ForeColor = Color.Black;
        }
        private void txt_search_Leave(object sender, EventArgs e)
        {
            //if (txt_search.Text == "")
            //{
            //    txt_search.Text = "Nhập từ khóa";
            //    txt_search.TextAlign = HorizontalAlignment.Center;
            //    txt_search.ForeColor = Color.Silver;
            //}
        }

        private void update_ckbox()
        {
            //if (cbb_filepath.Items.Count == 0)
            //    MessageBox.Show("Chưa có nhập filepath", "Lỗi");
            //else
            //{
            //    if (cbb_filepath.Text == "") MessageBox.Show("Chưa có chọn filepath", "Lỗi");
            //    else
            //    {
            //        string path = cbb_filepath.Text;

            //        if (path == null) listBoxFiles.Items.Clear();
            //        else UpdateFileList(path, null);
            //    }
            //}

            //int i = listBoxFiles.Items.Count;
            //while (i != 0)
            //    if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), "Folder") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), "folder") == true) { i--; }
            //    else
            //        if (ckbox_docx.Checked == true) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), "docx") == true) i--; }
            //    else if (ckbox_docx.Checked == true && ckbox_pdf.Checked == true)
            //    { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".docx") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".pdf") == true) i--; }
            //    else if (ckbox_docx.Checked == true && ckbox_pdf.Checked == true && ckbox_pptx.Checked == true)
            //    { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".docx") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".pdf") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".pptx") == true) i--; }
            //    else if (ckbox_docx.Checked == true && ckbox_pdf.Checked == true && ckbox_pptx.Checked == true && ckbox_rar.Checked == true)
            //    { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".docx") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".pdf") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".pptx") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".rar") == true) i--; }
            //    else if (ckbox_docx.Checked == true && ckbox_pdf.Checked == true && ckbox_pptx.Checked == true && ckbox_rar.Checked == true && ckbox_txt.Checked == true)
            //    { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".docx") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".pdf") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".pptx") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".rar") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".txt") == true) i--; }
            //    else if (ckbox_docx.Checked == true && ckbox_pdf.Checked == true && ckbox_pptx.Checked == true && ckbox_rar.Checked == true && ckbox_txt.Checked == true && ckbox_xlsx.Checked == true)
            //    { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".docx") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".pdf") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".pptx") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".rar") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".txt") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".xlsx") == true) i--; }
            //    else
            //    if (ckbox_pdf.Checked == true) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), "pdf") == true) i--; }
            //    else if (ckbox_pdf.Checked == true && ckbox_pptx.Checked == true)
            //    { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".pdf") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".pptx") == true) i--; }
            //    else if (ckbox_pdf.Checked == true && ckbox_pptx.Checked == true && ckbox_rar.Checked == true)
            //    { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".pdf") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".pptx") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".rar") == true) i--; }
            //    else if (ckbox_pdf.Checked == true && ckbox_pptx.Checked == true && ckbox_rar.Checked == true && ckbox_txt.Checked == true)
            //    { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".pdf") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".pptx") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".rar") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".txt") == true) i--; }
            //    else if (ckbox_pdf.Checked == true && ckbox_pptx.Checked == true && ckbox_rar.Checked == true && ckbox_txt.Checked == true && ckbox_xlsx.Checked == true)
            //    { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".pdf") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".pptx") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".rar") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".txt") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".xlsx") == true) i--; }
            //    else
            //    if (ckbox_pptx.Checked == true) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), "pptx") == true) i--; }
            //    else if (ckbox_pptx.Checked == true && ckbox_rar.Checked == true)
            //    { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".pptx") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".rar") == true) i--; }
            //    else if (ckbox_pptx.Checked == true && ckbox_rar.Checked == true && ckbox_txt.Checked == true)
            //    { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".pptx") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".rar") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".txt") == true) i--; }
            //    else if (ckbox_pptx.Checked == true && ckbox_rar.Checked == true && ckbox_txt.Checked == true && ckbox_xlsx.Checked == true)
            //    { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".pptx") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".rar") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".txt") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".xlsx") == true) i--; }
            //    else
            //    if (ckbox_rar.Checked == true) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), "rar") == true) i--; }
            //    else if (ckbox_rar.Checked == true && ckbox_txt.Checked == true)
            //    { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".rar") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".txt") == true) i--; }
            //    else if (ckbox_rar.Checked == true && ckbox_txt.Checked == true && ckbox_xlsx.Checked == true)
            //    { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".rar") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".txt") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".xlsx") == true) i--; }
            //    else
            //    if (ckbox_txt.Checked == true) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), "txt") == true) i--; }
            //    else if (ckbox_txt.Checked == true && ckbox_xlsx.Checked == true)
            //    { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".txt") == true || ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), ".xlsx") == true) i--; }
            //    else
            //    if (ckbox_xlsx.Checked == true) { if (ContainsSubstring(listBoxFiles.Items[i - 1].ToString(), "xlsx") == true) i--; }
            //    else
            //    {
            //        listBoxFiles.Items.RemoveAt(i - 1);
            //        i--;
            //    }

            int i = listBoxFiles.Items.Count;

            List<string> extensions = new List<string>();
            if (ckbox_docx.Checked) extensions.Add(".docx");
            if (ckbox_pdf.Checked) extensions.Add(".pdf");
            if (ckbox_pptx.Checked) extensions.Add(".pptx");
            if (ckbox_rar.Checked) extensions.Add(".rar");
            if (ckbox_txt.Checked) extensions.Add(".txt");
            if (ckbox_xlsx.Checked) extensions.Add(".xlsx");

            while (i != 0)
            {
                string currentItem = listBoxFiles.Items[i - 1].ToString();

                if (ContainsSubstring(currentItem, "Folder") || ContainsSubstring(currentItem, "folder"))
                {
                    i--;
                    continue;
                }

                bool matchesExtension = extensions.Any(ext => ContainsSubstring(currentItem, ext));
                if (!matchesExtension)
                {
                    listBoxFiles.Items.RemoveAt(i - 1); 
                }
                i--;
            }
        }

        private void ckbox_docx_CheckedChanged(object sender, EventArgs e)
        {
            if (cbb_filepath.Items.Count == 0)
            {
                MessageBox.Show("Chưa có nhập filepath", "Lỗi");
                ckbox_docx.Checked = false;
            }    
            else
            {
                if (cbb_filepath.Text == "")
                {
                    MessageBox.Show("Chưa có chọn filepath", "Lỗi");
                    ckbox_docx.Checked = false;
                }
                else
                {
                    //ckbox_docx.Checked = false;
                    string path = cbb_filepath.Text;
                    UpdateFileList(path, null);

                    if (path == null) listBoxFiles.Items.Clear();
                    else UpdateFileList(path, null);
                    update_ckbox();
                }
            }
        }

        private void ckbox_pdf_CheckedChanged(object sender, EventArgs e)
        {
            if (cbb_filepath.Items.Count == 0)
            {
                MessageBox.Show("Chưa có nhập filepath", "Lỗi");
                ckbox_pdf.Checked = false;
            }
            else
            {
                if (cbb_filepath.Text == "")
                {
                    MessageBox.Show("Chưa có chọn filepath", "Lỗi");
                    ckbox_pdf.Checked = false;
                }
                else
                {
                    //ckbox_pdf.Checked = false;
                    string path = cbb_filepath.Text;
                    UpdateFileList(path, null);

                    if (path == null) listBoxFiles.Items.Clear();
                    else UpdateFileList(path, null);
                    update_ckbox();
                }
            }
        }

        private void ckbox_pptx_CheckedChanged(object sender, EventArgs e)
        {
            if (cbb_filepath.Items.Count == 0)
            {
                MessageBox.Show("Chưa có nhập filepath", "Lỗi");
                ckbox_pptx.Checked = false;
            }
            else
            {
                if (cbb_filepath.Text == "")
                {
                    MessageBox.Show("Chưa có chọn filepath", "Lỗi");
                    ckbox_pptx.Checked = false;
                }
                else
                {
                    //ckbox_pptx.Checked = false;
                    string path = cbb_filepath.Text;
                    UpdateFileList(path, null);

                    if (path == null) listBoxFiles.Items.Clear();
                    else UpdateFileList(path, null);
                    update_ckbox();
                }
            }
        }

        private void ckbox_rar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbb_filepath.Items.Count == 0)
            {
                MessageBox.Show("Chưa có nhập filepath", "Lỗi");
                ckbox_rar.Checked = false;
            }
            else
            {
                if (cbb_filepath.Text == "")
                {
                    MessageBox.Show("Chưa có chọn filepath", "Lỗi");
                    ckbox_rar.Checked = false;
                }
                else
                {
                    //ckbox_rar.Checked = false;
                    string path = cbb_filepath.Text;
                    UpdateFileList(path, null);

                    if (path == null) listBoxFiles.Items.Clear();
                    else UpdateFileList(path, null);
                    update_ckbox();
                }
            }
        }

        private void ckbox_txt_CheckedChanged(object sender, EventArgs e)
        {
            if (cbb_filepath.Items.Count == 0)
            {
                MessageBox.Show("Chưa có nhập filepath", "Lỗi");
                ckbox_txt.Checked = false;
            }
            else
            {
                if (cbb_filepath.Text == "")
                {
                    MessageBox.Show("Chưa có chọn filepath", "Lỗi");
                    ckbox_txt.Checked = false;
                }
                else
                {
                    //ckbox_txt.Checked = false;
                    string path = cbb_filepath.Text;
                    UpdateFileList(path, null);

                    if (path == null) listBoxFiles.Items.Clear();
                    else UpdateFileList(path, null);
                    update_ckbox();
                }
            }
        }

        private void ckbox_xlsx_CheckedChanged(object sender, EventArgs e)
        {
            if (cbb_filepath.Items.Count == 0)
            {
                MessageBox.Show("Chưa có nhập filepath", "Lỗi");
                ckbox_xlsx.Checked = false;
            }
            else
            {
                if (cbb_filepath.Text == "")
                {
                    MessageBox.Show("Chưa có chọn filepath", "Lỗi");
                    ckbox_xlsx.Checked = false;
                }
                else
                {
                    //ckbox_xlsx.Checked = false;
                    string path = cbb_filepath.Text;
                    UpdateFileList(path, null);

                    if (path == null) listBoxFiles.Items.Clear();
                    else UpdateFileList(path, null);
                    update_ckbox();
                }
            }
        }
    }
}
