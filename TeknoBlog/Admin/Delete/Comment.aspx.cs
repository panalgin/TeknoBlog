using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeknoBlog.Admin.Delete
{
    public partial class _Comment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NameValueCollection m_Queries = this.Request.QueryString;

            if (m_Queries.HasKeys())
            {
                int m_ID = Convert.ToInt32(m_Queries.Get("ID"));

                if (m_ID > 0)
                {
                    using (BlogEntities m_Context = new BlogEntities())
                    {
                        Comment m_Comment = m_Context.Comments.Where(q => q.ID == m_ID).FirstOrDefault();

                        if (m_Comment != null)
                            m_Context.Comments.Remove(m_Comment);

                        m_Context.SaveChanges();
                    }
                }
            }

            Response.Redirect(Request.UrlReferrer.ToString());
        }
    }
}