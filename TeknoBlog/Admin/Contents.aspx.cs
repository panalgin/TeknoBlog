using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeknoBlog.Models;

namespace TeknoBlog.Admin
{
    public partial class Contents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using(BlogEntities m_Context = new BlogEntities())
            {
                var m_Posts = m_Context.Posts.ToList();

                ApplicationDbContext m_AspnetContext = new ApplicationDbContext();
                var m_Manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(m_AspnetContext));

                m_Posts.All(delegate (Post m_Post)
                {

                    var m_Author = m_Manager.FindById(m_Post.AuthorID);

                    this.Table_Body.InnerHtml += string.Format(
                                                    "<tr>" +
                                                        "<td>{0}</td>" +
                                                        "<td>{1}</td>" +
                                                        "<td>{2}</td>" +
                                                        "<td>{3}</td>" +
                                                        "<td><a href=\"/Admin/Edit/Content?ID={4}\">Düzenle</a> - <a href=\"/Admin/Delete/Content?ID={4}\">Sil</a></td>" +
                                                    "</tr>", m_Post.Caption, m_Author != null ? m_Author.Email : "-", m_Post.CreatedAt.ToString(), m_Post.Category.Name, m_Post.ID);

                    return true;
                });
            }
        }
    }
}