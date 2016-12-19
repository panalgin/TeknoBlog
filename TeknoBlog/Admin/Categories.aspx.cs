using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeknoBlog.Admin
{
    public partial class Categories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using(BlogEntities m_Context = new BlogEntities())
            {
                var m_Categories = m_Context.Categories.ToList();

                m_Categories.All(delegate (Category m_Category)
                {
                    this.Table_Body.InnerHtml += string.Format("<tr>" +
                                                                    "<td>{0}</td>" +
                                                                    "<td><a href=\"/Admin/Edit/Category?ID={1}\">Düzenle</a> - <a href=\"/Admin/Delete/Category?ID={1}\">Sil</a></td>" +
                                                                 "</tr>", m_Category.Name, m_Category.ID);
                    return true;
                });
            }
        }
    }
}