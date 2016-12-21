using BlogControl.ApiService;
using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace BlogControl
{
    public partial class Edit_Post_Pop : Form
    {
        public PostEx Post { get; set; }

        ChromiumWebBrowser m_Browser = null;
        private string EditorText = "";

        public Edit_Post_Pop()
        {
            InitializeComponent();

            m_Browser = new ChromiumWebBrowser(Path.Combine(Application.StartupPath, "View\\index.html"))
            {
                Dock = DockStyle.Fill,
            };

            this.panel1.Controls.Add(m_Browser);
        }

        private void Edit_Post_Pop_Load(object sender, EventArgs e)
        {
            using (ApiSoapClient m_Client = new ApiSoapClient())
            {
                var m_Categories = m_Client.GetCategories().ToList();

                this.comboBox1.DataSource = m_Categories;
                this.comboBox1.ValueMember = "ID";
                this.comboBox1.DisplayMember = "Name";

                this.comboBox1.Invalidate();
            }

            JavaScriptCallback m_Callback = new JavaScriptCallback();
            m_Callback.Changed += Callback_Changed;
            m_Callback.Ready += Callback_Ready;
            m_Browser.RegisterAsyncJsObject("windowsApp", m_Callback);

            this.EditorText = this.Post.Data;
            this.Caption_Box.Text = this.Post.Caption;
            this.comboBox1.SelectedValue = this.Post.CategoryID;
        }

        private void Callback_Ready()
        {
            var m_Decoded = WebUtility.HtmlDecode(this.Post.Data);
            var m_Injected = string.Format("tinyMCE.activeEditor.setContent(unescape(\"{0}\"));", HttpUtility.JavaScriptStringEncode(m_Decoded));
            m_Browser.ExecuteScriptAsync(m_Injected);
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
                using (ApiSoapClient m_Client = new ApiSoapClient())
                {
                    this.Post.Caption = this.Caption_Box.Text;
                    this.Post.CategoryID = Convert.ToInt32(this.comboBox1.SelectedValue.ToString());
                    this.Post.Data = this.EditorText;

                    var result = m_Client.UpdatePost(this.Post);

                    if (result == true)
                        this.Close();
                    else
                        MessageBox.Show("İçerik düzenlenirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private class JavaScriptCallback
        {
            public delegate void OnChanged(string message);
            public delegate void OnReady();

            public event OnChanged Changed;
            public event OnReady Ready;

            public string Data { get; set; }
            public void getMessage(string message)
            {
                InvokeChanged(message);
            }

            public void onReady()
            {
                InvokeReady();
            }

            public JavaScriptCallback()
            {

            }

            private void InvokeChanged(string message)
            {
                Changed?.Invoke(message);
            }

            private void InvokeReady()
            {
                Ready?.Invoke();
            }
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
