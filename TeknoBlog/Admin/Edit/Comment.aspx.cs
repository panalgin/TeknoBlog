using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeknoBlog.Admin.Edit
{
    public partial class _Comment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.Info.Visible = false;

                if (Request.QueryString.HasKeys())
                {
                    int m_CommentID = Convert.ToInt32(Request.QueryString.Get("ID"));

                    if (m_CommentID > 0)
                    {
                        using (BlogEntities m_Context = new BlogEntities())
                        {
                            Comment m_Comment = m_Context.Comments.Where(q => q.ID == m_CommentID).FirstOrDefault();

                            if (m_Comment != null)
                            {
                                this.Data_Box.Text = m_Comment.Data;
                            }
                        }
                    }
                }
            }
        }

        protected void Save_Button_Click(object sender, EventArgs e)
        {
            if (Request.QueryString.HasKeys())
            {
                int m_CommentID = Convert.ToInt32(Request.QueryString.Get("ID"));

                if (m_CommentID > 0)
                {
                    using (BlogEntities m_Context = new BlogEntities())
                    {
                        Comment m_Comment = m_Context.Comments.Where(q => q.ID == m_CommentID).FirstOrDefault();

                        if (m_Comment != null)
                        {
                            m_Comment.Data = this.Data_Box.Text;
                            m_Context.SaveChanges();
                            this.Info.Visible = true;
                        }
                    }
                }
            }
        }
    }
}