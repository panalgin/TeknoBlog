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
    public partial class Comments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (BlogEntities m_Context = new BlogEntities())
            {
                var m_Comments = m_Context.Comments.OrderByDescending(q => q.CreatedAt).ToList();

                ApplicationDbContext m_AspnetContext = new ApplicationDbContext();
                var m_Manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(m_AspnetContext));

                m_Comments.All(delegate (Comment comment)
                {
                    string m_Author = "-";
                    var m_User = m_Manager.FindById(comment.AuthorID);

                    if (m_User != null)
                        m_Author = m_User.UserName;

                    this.Table_Body.InnerHtml += string.Format("<tr>" +
                                                                    "<td>{0}</td>" +
                                                                    "<td>{1}</td>" +
                                                                    "<td>{2}</td>" +
                                                                    "<td>{3}</td>" +
                                                                    "<td><a href=\"/Admin/Edit/Comment?ID={4}\">Düzenle</a> - <a href=\"/Admin/Delete/Comment?ID={4}\">Sil</a></td>" +
                                                                 "</tr>", m_Author, comment.CreatedAt.ToShortDateString(), comment.Post.Caption, comment.Data.Substring(0, comment.Data.Length > 200 ? 199 : comment.Data.Length - 1), comment.ID);
                    return true;
                });
            }
        }
    }
}