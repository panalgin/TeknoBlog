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
    public partial class Add_User_Pop : Form
    {
        public Add_User_Pop()
        {
            InitializeComponent();
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (ValidateAll())
            {
                using(ApiSoapClient m_Client = new ApiSoapClient())
                {
                    UserEx m_User = new UserEx();
                    m_User.Email = this.Email_Box.Text;
                    m_User.Username = this.Username_Box.Text;
                    m_User.Password = this.Password_Box.Text;
                    m_User.IsAdministrator = this.IsAdministrator_Check.Checked;

                    var result = m_Client.AddUser(m_User);

                    if (result == true)
                        this.Close();
                    else
                        MessageBox.Show("Kullanıcı eklenirken bir hata ile karşılaşıldı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateAll()
        {
            bool m_Output = false;

            if (this.Email_Box.Text.Length < 3)
                MessageBox.Show("Geçerli bir email adresi giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else if (this.Username_Box.Text.Length < 3)
                MessageBox.Show("Geçerli bir email kullanıcı adı giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else if (this.Password_Box.Text.Length < 6 || this.Password_Box.Text.Length > 20)
                MessageBox.Show("Şifre en az 6, en fazla 20 karakterden oluşmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
                m_Output = true;

            return m_Output;
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
