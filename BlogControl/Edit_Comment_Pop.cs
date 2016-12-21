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
    public partial class Edit_Comment_Pop : Form
    {
        public CommentEx Comment { get; set; }

        public Edit_Comment_Pop()
        {
            InitializeComponent();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Edit_Comment_Pop_Load(object sender, EventArgs e)
        {
            if (this.Comment != null)
            {
                this.Author_Label.Text = this.Comment.AuthorName;
                this.Comment_Box.Text = this.Comment.Data;

                this.Comment_Box.Focus();
            }
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (this.Comment != null)
            {
                using(ApiSoapClient m_Client = new ApiSoapClient())
                {
                    this.Comment.Data = this.Comment_Box.Text;
                    var result = m_Client.UpdateComment(this.Comment);

                    if (result == true)
                    {
                        this.Close();
                    }
                }
            }
        }
    }
}
