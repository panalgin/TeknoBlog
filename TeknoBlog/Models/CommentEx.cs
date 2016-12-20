using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeknoBlog.Models
{
    public class CommentEx
    {
        public int ID { get; set; }
        public string AuthorName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Data { get; set; }
        public string PostName { get; set; }

        public static CommentEx CopyFrom(Comment comment)
        {
            CommentEx m_CommentEx = new CommentEx();

            using (ApplicationDbContext m_AspnetContext = new ApplicationDbContext())
            {
                var m_Manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(m_AspnetContext));

                m_CommentEx.ID = comment.ID;
                m_CommentEx.CreatedAt = comment.CreatedAt;
                m_CommentEx.Data = comment.Data;
                m_CommentEx.PostName = comment.Post.Caption;

                ApplicationUser m_Author = m_Manager.FindById(comment.AuthorID);

                if (m_Author != null)
                    m_CommentEx.AuthorName = m_Author.UserName;

            }

            return m_CommentEx;
        }
    }
}