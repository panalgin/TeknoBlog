using BlogControl.ApiService;
using BlogControl.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlogControl
{
    public partial class Login_Mdi : Form
    {
        public Login_Mdi()
        {
            InitializeComponent();
        }

        private void Login_Button_Click(object sender, EventArgs e)
        {
            this.Login_Button.Enabled = false;

            using (ApiSoapClient m_Client = new ApiSoapClient())
            {
                var result = m_Client.Login(this.Email_Box.Text, this.Password_Box.Text);

                if (result == true)
                {
                    UserEx m_User = m_Client.GetUser(this.Email_Box.Text);

                    if (m_User != null)
                    {
                        EventSink.InvokeLogin(new LoginEventArgs() { User = m_User, OccuredAt = DateTime.Now });

                        this.Close();
                    }
                }
            }

            this.Login_Button.Enabled = true;
        }

        private void Login_Mdi_Load(object sender, EventArgs e)
        {
            this.Email_Box.Focus();
        }

        private void Email_Box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                this.Login_Button.PerformClick();
        }

        private void Password_Box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                this.Login_Button.PerformClick();
        }
    }
}
