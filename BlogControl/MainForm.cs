using BlogControl.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlogControl
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            EventSink.Login += EventSink_Login;

            Login_Mdi m_Mdi = new Login_Mdi();
            m_Mdi.MdiParent = this;
            m_Mdi.Show();
        }

        private void EventSink_Login(LoginEventArgs args)
        {
            this.Tool_Strip.Enabled = true;
            Program.User = args.User;
        }

        private void Categories_Button_Click(object sender, EventArgs e)
        {
            Manage_Categories_Mdi m_Mdi = new Manage_Categories_Mdi();
            m_Mdi.MdiParent = this;
            m_Mdi.Show();
        }

        private void Comments_Button_Click(object sender, EventArgs e)
        {
            Manage_Comments_Mdi m_Mdi = new Manage_Comments_Mdi();
            m_Mdi.MdiParent = this;
            m_Mdi.Show();
        }
    }
}
