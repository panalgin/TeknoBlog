using HtmlAgilityPack;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeknoBlog.Models;

namespace TeknoBlog
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using(BlogEntities m_Context = new BlogEntities())
            {
                int m_Index = 0;

                ApplicationDbContext m_AspnetContext = new ApplicationDbContext();
                var m_Manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(m_AspnetContext));

                var m_Categories = m_Context.Categories.ToList();

                m_Categories.All(delegate (Category m_Category)
                {
                    this.cat_links.InnerHtml += string.Format("<li><a href=\"Category?id={0}\">{1}</a></li>", m_Category.ID, m_Category.Name);
                    this.ConHold.InnerHtml += string.Format("<div class=\"\"><h2>{0}</h2></div>", m_Category.Name);
                    this.ConHold.InnerHtml += "<div class=\"row\">";

                    var m_Posts = m_Context.Posts.Where(q => q.CategoryID == m_Category.ID).OrderByDescending(q => q.CreatedAt).Take(3).ToList();

                    string m_Template = "<div class=\"col-md-4\">" +
                                            "<a class=\"header\" href=\"View?ID={2}\">{0}</a>" +
                                            "<p>{1} <a href=\"View?ID={2}\">Devamı</a><p>" +
                                            "<p>Yazar: {3}, Tarih: {4}</p>" +
                                        "</div>";

                    if (m_Posts.Count == 0)
                        this.ConHold.InnerHtml += "<div class=\"row\"><div class=\"span6 offset4\" ><div class=\"tweaked-margin\">Bu kategoride yazılmış bir yazı yok.</div></div></div>";
                    else
                    {
                        m_Posts.All(delegate (Post post)
                        {
                            HtmlDocument m_Doc = new HtmlDocument();
                            m_Doc.LoadHtml(HttpUtility.HtmlDecode(post.Data));
                            var m_Text = m_Doc.DocumentNode.InnerText;
                            string clean = m_Doc.DocumentNode.InnerText.Substring(0, m_Text.Length > 200 ? 199 : m_Text.Length - 1);
                            clean += "...";

                            string m_Author = "";
                            var m_User = m_Manager.FindById(post.AuthorID);

                            if (m_User != null)
                                m_Author = m_User.UserName;
                            else
                                m_Author = "-";

                            this.ConHold.InnerHtml += string.Format(m_Template, post.Caption, clean, post.ID, m_Author, post.CreatedAt.ToShortDateString());

                            m_Index++;

                            return true;
                        });
                    }

                    this.ConHold.InnerHtml += "</div>";

                    return true;
                });
            }
        }
    }
}