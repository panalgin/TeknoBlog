using HtmlAgilityPack;
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
    public partial class _Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (BlogEntities m_Context = new BlogEntities())
            {
                NameValueCollection m_Query = this.Request.QueryString;

                if (m_Query.HasKeys())
                {
                    int m_CatID = Convert.ToInt32(m_Query.Get("ID"));

                    if (m_CatID > 0)
                    {
                        Category m_Category = m_Context.Categories.Where(q => q.ID == m_CatID).FirstOrDefault();
                        Page.Title = m_Category.Name;

                        int m_Index = 0;

                        this.ConHold.InnerHtml += string.Format("<div class=\"\"><h2>{0}</h2></div>", m_Category.Name);

                        var m_Posts = m_Context.Posts.Where(q => q.CategoryID == m_Category.ID).OrderByDescending(q => q.CreatedAt).ToList();

                        ApplicationDbContext m_AspnetContext = new ApplicationDbContext();
                        var m_Manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(m_AspnetContext));

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
                                if (m_Index == 0 || m_Index % 3 == 0)
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

                            if (m_Index % 3 != 0)
                                this.ConHold.InnerHtml += "</div>";
                        }

                        
                    }
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
}