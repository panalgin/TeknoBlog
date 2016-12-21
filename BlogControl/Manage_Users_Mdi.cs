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
    }
}
