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
    public partial class Manage_Posts_Mdi : Form
    {
        public Manage_Posts_Mdi()
        {
            InitializeComponent();
        }

        private void Manage_Posts_Mdi_Load(object sender, EventArgs e)
        {
            this.PopulateList();
        }

        void PopulateList()
        {
            this.Posts_List.Items.Clear();
            this.Posts_List.BeginUpdate();

            using(ApiSoapClient m_Client = new ApiSoapClient())
            {
                var m_Posts = m_Client.GetPosts();
            }

            this.Posts_List.EndUpdate();
        }
    }
}
