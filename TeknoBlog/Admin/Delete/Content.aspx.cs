using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeknoBlog.Admin.Delete
{
    public partial class _Content : System.Web.UI.Page
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
                        Post m_Post = m_Context.Posts.Where(q => q.ID == m_ID).FirstOrDefault();

                        if (m_Post != null)
                            m_Context.Posts.Remove(m_Post);

                        m_Context.SaveChanges();
                    }
                }
            }

            Response.Redirect(Request.UrlReferrer.ToString());
        }
    }
}