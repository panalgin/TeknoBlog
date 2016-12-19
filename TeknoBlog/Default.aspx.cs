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
                var m_Posts = m_Context.Posts.ToList();

                string m_Template = "<div class=\"col-md-4\">" +
                                        "<a class=\"header\" href=\"View?ID={2}\">{0}</a>" +
                                        "<p>{1} <a href=\"View?ID={2}\">Devamı</a><p>" +
                                        "<p>Yazar: {3}, Tarih: {4}</p>" + 
                                    "</div>";
                int m_Index = 0;

                ApplicationDbContext m_AspnetContext = new ApplicationDbContext();
                var m_Manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(m_AspnetContext));

                m_Posts.All(delegate (Post post)
                {
                    if (m_Index % 3 == 0)
                        this.ConHold.InnerHtml += "<div class=\"row\">";

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

                    if (m_Index % 3 == 0)
                        this.ConHold.InnerHtml += "</div>";

                    return true;
                });

                if (m_Posts.Count % 3 != 0)
                    this.ConHold.InnerHtml += "</div>";
            }
        }
    }
}