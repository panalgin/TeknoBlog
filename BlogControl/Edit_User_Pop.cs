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
    public partial class Edit_User_Pop : Form
    {
        public UserEx User { get; set; }

        public Edit_User_Pop()
        {
            InitializeComponent();
        }

        private void Edit_User_Pop_Load(object sender, EventArgs e)
        {
            this.Email_Label.Text = this.User.Email;
            this.Username_Box.Text = this.User.Username;

            if (this.User.IsAdministrator)
                this.IsAdministrator_Check.Checked = true;
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (this.User != null)
            {
                using (ApiSoapClient m_Client = new ApiSoapClient())
                {
                    this.User.Username = this.Username_Box.Text;
                    this.User.IsAdministrator = this.IsAdministrator_Check.Checked;

                    var result = m_Client.UpdateUser(this.User);

                    if (result == true)
                    {
                        this.Close();
                    }
                }
            }
        }
    }
}
