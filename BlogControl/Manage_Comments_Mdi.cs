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
    public partial class Manage_Comments_Mdi : Form
    {
        public Manage_Comments_Mdi()
        {
            InitializeComponent();
        }

        private void Manage_Comments_Mdi_Load(object sender, EventArgs e)
        {
            this.PopulateList();
        }

        void PopulateList()
        {
            this.Comments_List.Items.Clear();
            this.Comments_List.BeginUpdate();

            using(ApiSoapClient m_Client = new ApiSoapClient())
            {
                var m_Comments = m_Client.GetComments();

                m_Comments.All(delegate (CommentEx comment)
                {
                    ListViewItem m_Item = new ListViewItem();
                    m_Item.Tag = comment.ID;
                    m_Item.Text = comment.ID.ToString();
                    m_Item.SubItems.Add(comment.AuthorName);
                    m_Item.SubItems.Add(comment.PostName);
                    m_Item.SubItems.Add(comment.Data);
                    m_Item.SubItems.Add(comment.CreatedAt.ToString());

                    this.Comments_List.Items.Add(m_Item);

                    return true;
                });
            }

            this.Comments_List.EndUpdate();
        }

        private void Comments_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Comments_List.SelectedItems.Count > 0)
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
            if (this.Comments_List.SelectedItems.Count > 0)
            {
                int m_CommentID = Convert.ToInt32(this.Comments_List.SelectedItems[0].Tag);
                string m_Author = this.Comments_List.SelectedItems[0].SubItems[1].Text;

                if (MessageBox.Show(string.Format("{0} adlı üyenin yaptığı yorum silinecek, onaylıyor musunuz?", m_Author), "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (ApiSoapClient m_Client = new ApiSoapClient())
                    {
                        var result = m_Client.DeleteComment(m_CommentID);
                    }

                    this.PopulateList();
                }
            }
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {

            if (this.Comments_List.SelectedItems.Count > 0)
            {
                int m_CommentID = Convert.ToInt32(this.Comments_List.SelectedItems[0].Tag);

                using (ApiSoapClient m_Client = new ApiSoapClient())
                {
                    CommentEx m_Comment = m_Client.GetComment(m_CommentID);

                    if (m_Comment != null)
                    {
                        Edit_Comment_Pop m_Pop = new Edit_Comment_Pop();
                        m_Pop.Comment = m_Comment;
                        m_Pop.ShowDialog();
                        this.PopulateList();
                    }
                }

            }
        }
    }
}
