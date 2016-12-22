using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeknoBlog.Models;

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

                using (BlogEntities m_Context = new BlogEntities())
                {
                    ApplicationDbContext m_AspnetContext = new ApplicationDbContext();
                    var m_Manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(m_AspnetContext));

                    Post m_Post = m_Context.Posts.Where(q => q.ID == m_ID).FirstOrDefault();

                    if (m_Post != null)
                    {
                        this.Caption.InnerText = m_Post.Caption;
                        this.Content.InnerHtml = HttpUtility.HtmlDecode(m_Post.Data);
                        Page.Title += m_Post.Caption;

                        var m_Comments = m_Context.Comments.Where(q => q.PostID == m_Post.ID).OrderByDescending(q => q.CreatedAt).ToList();

                        string m_Template = "<div class=\"row comment\">" +
                                                "<div class=\"col-sm-1\">" +
                                                    "<div class=\"thumbnail\">" +
                                                        "<img class=\"img-responsive user-photo\" src=\"https://ssl.gstatic.com/accounts/ui/avatar_2x.png\">" +
                                                    "</div>" +
                                                "</div>" +
                                                "<div class=\"col-sm-8\">" +
                                                    "<div class=\"panel panel-default\">" +
                                                        "<div class=\"panel-heading\">" +
                                                            "<strong>{0}</strong> <span class=\"text-muted\">{1} tarihinde:</span> {2}" +
                                                        "</div>" +
                                                    "</div>" +
                                                "</div>" +
                                            "</div>";

                        m_Comments.All(delegate (Comment comment)
                        {
                            string m_Author = "-";

                            var m_User = m_Manager.FindById(comment.AuthorID);

                            if (m_User != null)
                                m_Author = m_User.UserName;

                            this.Comments.InnerHtml += string.Format(m_Template, m_Author, comment.CreatedAt.ToShortDateString(), comment.Data);

                            return true;
                        });
                    }

                    var m_Categories = m_Context.Categories.ToList();

                    m_Categories.All(delegate (Category m_Category)
                    {
                        this.cat_links.InnerHtml += string.Format("<li><a href=\"Category?ID={0}\">{1}</a></li>", m_Category.ID, m_Category.Name);

                        return true;
                    });
                }
            }
        }

        protected void Submit_Comment_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                NameValueCollection m_Query = Request.QueryString;

                if (m_Query.HasKeys() && Context.User.Identity != null)
                {
                    int m_PostID = Convert.ToInt32(m_Query.Get("ID"));

                    if (m_PostID > 0) {
                        ApplicationDbContext m_AspnetContext = new ApplicationDbContext();
                        var m_Manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(m_AspnetContext));
                        var m_Author = m_Manager.FindByName(HttpContext.Current.User.Identity.GetUserName());

                        using (BlogEntities m_Context = new BlogEntities())
                        {
                            Post m_Post = m_Context.Posts.Where(q => q.ID == m_PostID).FirstOrDefault();

                            if (m_Post != null)
                            {
                                Comment m_Comment = new Comment();
                                m_Comment.AuthorID = m_Author.Id;
                                m_Comment.CreatedAt = DateTime.Now;
                                TextBox m_Comment_Box = this.Login_View.FindControl("Comment_Box") as TextBox;
                                m_Comment.Data = m_Comment_Box.Text;
                                m_Comment.PostID = m_Post.ID;

                                m_Context.Comments.Add(m_Comment);
                                m_Context.SaveChanges();

                                Response.Redirect(string.Format("View?ID={0}", m_PostID));
                            }
                        }
                    }
                }
            }
        }
    }
}