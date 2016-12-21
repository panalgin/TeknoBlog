using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeknoBlog.Models
{
    public class PostEx
    {
        public int ID { get; set; }
        public string AuthorID { get; set; }
        public string AuthorName { get; set; }
        public string Caption { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Data { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public static PostEx CopyFrom(Post post, bool fullCopy = true)
        {
            using (ApplicationDbContext m_AspnetContext = new ApplicationDbContext())
            {
                var m_Manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(m_AspnetContext));

                PostEx m_Post = new PostEx();

                m_Post.ID = post.ID;
                m_Post.Caption = post.Caption;
                m_Post.CreatedAt = post.CreatedAt;
                m_Post.CategoryID = post.CategoryID;
                m_Post.CategoryName = post.Category != null ? post.Category.Name : "Yok";

                if (fullCopy)
                    m_Post.Data = post.Data;

                ApplicationUser m_Author = m_Manager.FindById(post.AuthorID);

                if (m_Author != null)
                {
                    m_Post.AuthorID = m_Author.Id;
                    m_Post.AuthorName = m_Author.UserName;
                }
                else
                {
                    m_Post.AuthorID = "";
                    m_Post.AuthorName = "Yok";
                }

                return m_Post;
            }
        }
    }
}