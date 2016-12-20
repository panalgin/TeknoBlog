using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using TeknoBlog.Models;

namespace TeknoBlog
{
    /// <summary>
    /// Summary description for Api
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Api : System.Web.Services.WebService
    {
        [WebMethod]
        public List<Post> GetPosts()
        {
            List<Post> m_List = new List<Post>();

            using(BlogEntities m_Context = new BlogEntities())
            {
                m_Context.Configuration.ProxyCreationEnabled = false;

                m_List = m_Context.Posts.ToList();
            }

            return m_List;
        }

        [WebMethod]
        public bool Login(string email, string password)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

            var result = signinManager.PasswordSignIn(email, password, false, shouldLockout: false);

            return result == SignInStatus.Success ? true : false;
        }

        [WebMethod]
        public UserEx GetUser(string email)
        {
            using (ApplicationDbContext m_Context = new ApplicationDbContext())
            {
                var m_Manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(m_Context));
                var m_User = m_Manager.FindByEmail(email);

                if (m_User != null)
                {
                    return UserEx.CopyFrom(m_User);
                }
                else
                    return null;
            }
        }

        #region Category Crud Operations
        [WebMethod]
        public List<Category> GetCategories()
        {
            List<Category> m_List = new List<Category>();

            using(BlogEntities m_Context = new BlogEntities())
            {
                m_Context.Configuration.ProxyCreationEnabled = false;
                m_List = m_Context.Categories.ToList();
            }

            return m_List;
        }

        [WebMethod]
        public Category GetCategory(int id)
        {
            Category m_Category = null;

            using(BlogEntities m_Context = new BlogEntities())
            {
                m_Context.Configuration.ProxyCreationEnabled = false;
                m_Category = m_Context.Categories.Where(q => q.ID == id).FirstOrDefault();
            }

            return m_Category;
        }

        [WebMethod]
        public bool DeleteCategory(int id)
        {
            using(BlogEntities m_Context = new BlogEntities())
            {
                var m_Category = m_Context.Categories.Where(q => q.ID == id).FirstOrDefault();

                if (m_Category != null)
                {
                    m_Context.Categories.Remove(m_Category);
                    m_Context.SaveChanges();

                    return true;
                }
                else
                    return false;
            }
        }

        [WebMethod]
        public bool AddCategory(Category category)
        {
            using(BlogEntities m_Context = new BlogEntities())
            {
                if (category.Name.Length > 0)
                {
                    m_Context.Categories.Add(category);
                    m_Context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
        }

        [WebMethod]
        public bool UpdateCategory(Category category)
        {

            using(BlogEntities m_Context = new BlogEntities())
            {
                Category m_Actual = m_Context.Categories.Where(q => q.ID == category.ID).FirstOrDefault();

                if (m_Actual != null)
                {
                    m_Actual.Name = category.Name;
                    m_Context.SaveChanges();

                    return true;
                }
                else
                    return false;
            }
        }
        #endregion
        #region Comment Crud Operations

        [WebMethod]
        public List<CommentEx> GetComments()
        {
            List<CommentEx> m_Comments = new List<CommentEx>();

            using (BlogEntities m_Context = new BlogEntities())
            {
                var result = m_Context.Comments.ToList();

                result.All(delegate (Comment comment)
                {
                    CommentEx m_CommentEx = CommentEx.CopyFrom(comment);

                    m_Comments.Add(m_CommentEx);

                    return true;
                });
            }

            return m_Comments;
        }

        [WebMethod]
        public CommentEx GetComment(int id)
        {
            CommentEx m_Comment = null;

            using (BlogEntities m_Context = new BlogEntities())
            {
                var result = m_Context.Comments.Where(q => q.ID == id).FirstOrDefault();

                if (result != null)
                    m_Comment = CommentEx.CopyFrom(result);
            }

            return m_Comment;
        }

        [WebMethod]
        public bool UpdateComment(CommentEx comment)
        {
            using(BlogEntities m_Context = new BlogEntities())
            {
                Comment m_Actual = m_Context.Comments.Where(q => q.ID == comment.ID).FirstOrDefault();

                if (m_Actual != null)
                {
                    m_Actual.Data = comment.Data;
                    m_Context.SaveChanges();

                    return true;
                }
                else
                    return false;
            }
        }

        [WebMethod]
        public bool DeleteComment(int id)
        {
            using (BlogEntities m_Context = new BlogEntities())
            {
                Comment m_Actual = m_Context.Comments.Where(q => q.ID == id).FirstOrDefault();

                if (m_Actual != null)
                {
                    m_Context.Comments.Remove(m_Actual);
                    m_Context.SaveChanges();

                    return true;
                }
                else
                    return false;
            }
        }

        #endregion
    }
}
