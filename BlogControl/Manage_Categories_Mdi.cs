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
    public partial class Manage_Categories_Mdi : Form
    {
        public Manage_Categories_Mdi()
        {
            InitializeComponent();
        }

        private void Manage_Categories_Mdi_Load(object sender, EventArgs e)
        {

            this.PopulateList();
        }

        void PopulateList()
        {
            this.Categories_List.Items.Clear();
            this.Categories_List.BeginUpdate();

            List<Category> m_Categories = new List<Category>();

            using (ApiSoapClient m_Client = new ApiSoapClient())
            {
                m_Categories = m_Client.GetCategories().ToList();
            }

            m_Categories.All(delegate (Category category)
            {
                ListViewItem m_Item = new ListViewItem();
                m_Item.Tag = category.ID;
                m_Item.Text = category.ID.ToString();
                m_Item.SubItems.Add(category.Name);

                this.Categories_List.Items.Add(m_Item);

                return true;
            });

            this.Categories_List.EndUpdate();
        }

        private void Categories_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Categories_List.SelectedItems.Count > 0)
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

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            if (this.Categories_List.SelectedItems.Count > 0)
            {
                int m_CategoryID = Convert.ToInt32(this.Categories_List.SelectedItems[0].Tag);
                string m_Name = this.Categories_List.SelectedItems[0].SubItems[1].Text;

                if (MessageBox.Show(string.Format("{0} adlı kategori silinecek, onaylıyor musunuz?", m_Name), "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using(ApiSoapClient m_Client = new ApiSoapClient())
                    {
                        var result = m_Client.DeleteCategory(m_CategoryID);
                    }

                    this.PopulateList();
                }
            }
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            if (this.Categories_List.SelectedItems.Count > 0)
            {
                int m_CategoryID = Convert.ToInt32(this.Categories_List.SelectedItems[0].Tag);

                using(ApiSoapClient m_Client = new ApiSoapClient())
                {
                    Category m_Category = m_Client.GetCategory(m_CategoryID);

                    if (m_Category != null)
                    {
                        Edit_Category_Pop m_Pop = new Edit_Category_Pop();
                        m_Pop.Category = m_Category;
                        m_Pop.ShowDialog();
                        this.PopulateList();
                    }
                }

            }
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            Add_Category_Pop m_Pop = new Add_Category_Pop();
            m_Pop.ShowDialog();

            this.PopulateList();
        }
    }
}
