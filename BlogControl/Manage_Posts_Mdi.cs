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
            PopulateList();
        }

        void PopulateList()
        {
            Posts_List.Items.Clear();
            Posts_List.BeginUpdate();

            using(ApiSoapClient m_Client = new ApiSoapClient())
            {
                var m_Posts = m_Client.GetPosts();

                m_Posts.All(delegate (PostEx post)
                {
                    ListViewItem m_Item = new ListViewItem();
                    m_Item.Tag = post.ID;
                    m_Item.Text = post.ID.ToString();
                    m_Item.SubItems.Add(post.AuthorName);
                    m_Item.SubItems.Add(post.Caption);
                    m_Item.SubItems.Add(post.CategoryName);
                    m_Item.SubItems.Add(post.CreatedAt.ToString());

                    Posts_List.Items.Add(m_Item);

                    return true;
                });
            }

            Posts_List.EndUpdate();
        }
    }
}
