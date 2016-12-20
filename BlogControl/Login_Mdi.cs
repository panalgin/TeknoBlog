using BlogControl.ApiService;
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
            using (ApiSoapClient m_Client = new ApiSoapClient())
            {
                var result = m_Client.Login(this.Email_Box.Text, this.Password_Box.Text);

                if (result == true)
                {
                    User m_User = m_Client.GetUser(this.Email_Box.Text);

                    EventSink.InvokeLogin(User);

                    this.Close();
                }
            }
        }
    }
}
