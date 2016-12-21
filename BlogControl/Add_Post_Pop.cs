using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using BlogControl.ApiService;

namespace BlogControl
{
    public partial class Add_Post_Pop : Form
    {
        ChromiumWebBrowser m_Browser = null;
        private string EditorText = "";

        public Add_Post_Pop()
        {
            InitializeComponent();

            m_Browser = new ChromiumWebBrowser(Path.Combine(Application.StartupPath, "View\\index.html"))
            {
                Dock = DockStyle.Fill,
            };

            this.panel1.Controls.Add(m_Browser);
        }

        private void Add_Post_Mdi_Load(object sender, EventArgs e)
        {
            using(ApiSoapClient m_Client = new ApiSoapClient())
            {
                var m_Categories = m_Client.GetCategories().ToList();

                this.comboBox1.DataSource = m_Categories;
                this.comboBox1.ValueMember = "ID";
                this.comboBox1.DisplayMember = "Name";

                this.comboBox1.Invalidate();
            }

            JavaScriptCallback m_Callback = new JavaScriptCallback();
            m_Callback.Changed += Callback_Changed;
            m_Browser.RegisterAsyncJsObject("windowsApp", m_Callback);
        }

        private void Callback_Changed(string message)
        {
            this.EditorText = message;
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (this.Caption_Box.Text.Length < 3)
                MessageBox.Show("En az 3 karakterden oluşan bir başlık girmelisiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                using(ApiSoapClient m_Client = new ApiSoapClient())
                {
                    PostEx m_Post = new PostEx();
                    m_Post.AuthorID = Program.User.ID;
                    m_Post.Caption = this.Caption_Box.Text;
                    m_Post.CategoryID = Convert.ToInt32(this.comboBox1.SelectedValue.ToString());
                    m_Post.CreatedAt = DateTime.Now;
                    m_Post.Data = this.EditorText;

                    var result = m_Client.AddPost(m_Post);

                    if (result == true)
                        this.Close();
                    else
                        MessageBox.Show("İçerik eklenmeye çalışılırken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private class JavaScriptCallback
        {
            public delegate void OnChanged(string message);
            public event OnChanged Changed;

            public string Data { get; set; }
            public void getMessage(string message)
            {
                InvokeChanged(message);
            }

            public JavaScriptCallback()
            { 

            }

            private void InvokeChanged(string message)
            {
                Changed?.Invoke(message);
            }
        }
    }
}
