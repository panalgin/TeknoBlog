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
    public partial class Manage_Users_Mdi : Form
    {
        public Manage_Users_Mdi()
        {
            InitializeComponent();
        }

        private void Manage_Users_Mdi_Load(object sender, EventArgs e)
        {
            this.PopulateList();
        }

        void PopulateList()
        {
            this.Users_List.Items.Clear();
            this.Users_List.BeginUpdate();

            using(ApiSoapClient m_Client = new ApiSoapClient())
            {
                var m_Users = m_Client.GetUsers();

                m_Users.All(delegate (UserEx user)
                {
                    ListViewItem m_Item = new ListViewItem();
                    m_Item.Tag = user.Email;
                    m_Item.Text = user.Username;
                    m_Item.SubItems.Add(user.Email);
                    m_Item.SubItems.Add(user.IsAdministrator ? "Administrator" : "User");

                    this.Users_List.Items.Add(m_Item);

                    return true;
                });
            }

            this.Users_List.EndUpdate();
        }

        private void Users_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Users_List.SelectedItems.Count > 0)
            {
                this.Edit_Button.Enabled = true;
                this.Delete_Button.Enabled = true;
            }
            else
            {
                this.Edit_Button.Enabled = false;
                this.Delete_Button.Enabled = false;
            }
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            if (this.Users_List.SelectedItems.Count > 0)
            {
                string m_Email = this.Users_List.SelectedItems[0].Tag.ToString();

                using (ApiSoapClient m_Client = new ApiSoapClient())
                {
                    UserEx m_User = m_Client.GetUser(m_Email);

                    if (m_User != null)
                    {
                        Edit_User_Pop m_Pop = new Edit_User_Pop();
                        m_Pop.User = m_User;
                        m_Pop.ShowDialog();

                        this.PopulateList();
                    }
                }
            }
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            if (this.Users_List.SelectedItems.Count > 0)
            {
                string m_Email = this.Users_List.SelectedItems[0].Tag.ToString();

                if (MessageBox.Show(string.Format("{0} email adresli üye silinecek, onaylıyor musunuz?", m_Email), "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (ApiSoapClient m_Client = new ApiSoapClient())
                    {
                        var result = m_Client.DeleteUser(m_Email);
                    }

                    this.PopulateList();
                }
            }
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            Add_User_Pop m_Pop = new Add_User_Pop();
            m_Pop.ShowDialog();

            this.PopulateList();
        }
    }
}
