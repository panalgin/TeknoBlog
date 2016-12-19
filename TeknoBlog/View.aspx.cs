using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeknoBlog
{
    public partial class View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NameValueCollection m_Query = this.Request.QueryString;

            if (m_Query.HasKeys())
            {
                int m_ID = Convert.ToInt32(m_Query.Get("ID"));

                using(BlogEntities m_Context = new BlogEntities())
                {
                    Post m_Post = m_Context.Posts.Where(q => q.ID == m_ID).FirstOrDefault();

                    if (m_Post != null)
                    {
                        this.Caption.InnerText = m_Post.Caption;
                        this.Content.InnerHtml = HttpUtility.HtmlDecode(m_Post.Data);
                    }
                }
            }
        }
    }
}