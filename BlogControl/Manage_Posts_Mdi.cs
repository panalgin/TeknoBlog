﻿using BlogControl.ApiService;
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

        private void Add_Button_Click(object sender, EventArgs e)
        {
            Add_Post_Pop m_Pop = new Add_Post_Pop();
            m_Pop.ShowDialog();

            this.PopulateList();
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            if (this.Posts_List.SelectedItems.Count > 0)
            {
                int m_PostID = Convert.ToInt32(this.Posts_List.SelectedItems[0].Tag);

                using (ApiSoapClient m_Client = new ApiSoapClient())
                {
                    var m_Post = m_Client.GetPost(m_PostID);

                    if (m_Post != null)
                    {
                        Edit_Post_Pop m_Pop = new Edit_Post_Pop();
                        m_Pop.Post = m_Post;
                        m_Pop.ShowDialog();

                        PopulateList();
                    }
                }

            }
        }

        private void Posts_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Posts_List.SelectedItems.Count > 0)
            {
                this.Edit_Button.Enabled = true;
                this.Delete_Button.Enabled = true;
            }
            else
            {
                this.Delete_Button.Enabled = false;
                this.Edit_Button.Enabled = false;
            }
        }
    }
}
