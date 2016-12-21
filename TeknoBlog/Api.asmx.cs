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
        #region Post Crud Operations
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
        public Post GetPost(int id)
        {
            Post m_Post = null;

            using (BlogEntities m_Context = new BlogEntities())
            {
                m_Context.Configuration.ProxyCreationEnabled = false;
                m_Post = m_Context.Posts.Where(q => q.ID == id).FirstOrDefault();
            }

            return m_Post;
        }

        [WebMethod]
        public bool AddPost(Post post)
        {
            using(BlogEntities m_Context = new BlogEntities())
            {
                if (post != null)
                {
                    m_Context.Posts.Add(post);
                    m_Context.SaveChanges();

                    return true;
                }
                else
                    return false;
            }
        }

        [WebMethod]
        public bool DeletePost(int id)
        {
            using(BlogEntities m_Context = new BlogEntities())
            {
                Post m_Post = m_Context.Posts.Where(q => q.ID == id).FirstOrDefault();

                if (m_Post != null)
                {
                    m_Context.Posts.Remove(m_Post);
                    m_Context.SaveChanges();

                    return true;
                }
                else
                    return false;
            }
        }

        [WebMethod]
        public bool UpdatePost(Post post)
        {
            using(BlogEntities m_Context = new BlogEntities())
            {
                Post m_Actual = m_Context.Posts.Where(q => q.ID == post.ID).FirstOrDefault();

                if (m_Actual != null)
                {
                    m_Actual.Caption = post.Caption;
                    m_Actual.Data = post.Data;
                    m_Actual.CategoryID = post.CategoryID;

                    m_Context.SaveChanges();

                    return true;
                }
                else
                    return false;
            }
        }
        #endregion
        #region User Crud Operations
        [WebMethod]
        public bool Login(string username, string password)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

            var result = signinManager.PasswordSignIn(username, password, false, shouldLockout: false);

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

        [WebMethod]
        public UserEx GetUserByUsername(string username)
        {

            using (ApplicationDbContext m_Context = new ApplicationDbContext())
            {
                var m_Manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(m_Context));
                var m_User = m_Manager.FindByName(username);

                if (m_User != null)
                {
                    return UserEx.CopyFrom(m_User);
                }
                else
                    return null;
            }
        }

        [WebMethod]
        public List<UserEx> GetUsers()
        {
            List<UserEx> m_List = new List<UserEx>();

            using(ApplicationDbContext m_Context = new ApplicationDbContext())
            {
                var m_Manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(m_Context));
                var m_Users = m_Manager.Users.ToList();

                m_Users.All(delegate (ApplicationUser user)
                {
                    UserEx m_User = UserEx.CopyFrom(user);
                    m_List.Add(m_User);

                    return true;
                });
            }

            return m_List;
        }

        [WebMethod]
        public bool DeleteUser(string email)
        {
            using(ApplicationDbContext m_Context = new ApplicationDbContext())
            {
                var m_Manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(m_Context));
                ApplicationUser m_Actual = m_Manager.FindByEmail(email);

                if (m_Actual != null)
                {
                    m_Manager.Delete(m_Actual);
                    return true;
                }
                else
                    return false;
            }
        }

        [WebMethod]
        public bool AddUser(UserEx ex)
        {
            using(ApplicationDbContext m_Context = new ApplicationDbContext())
            {
                var m_Manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(m_Context));

                ApplicationUser m_User = new ApplicationUser();
                m_User.Email = ex.Email;
                m_User.UserName = ex.Email;

                var result = m_Manager.Create(m_User, ex.Password);

                if (result.Succeeded)
                {
                    if (ex.IsAdministrator)
                    {
                        if (m_Manager.IsInRole(m_User.Id, "Administrator") == false)
                            m_Manager.AddToRole(m_User.Id, "Administrator");
                    }

                    return true;
                }
                else
                    return false;
            }
        }

        [WebMethod]
        public bool UpdateUser(UserEx ex)
        {
            using(ApplicationDbContext m_Context = new ApplicationDbContext())
            {
                var m_Manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(m_Context));
                ApplicationUser m_Actual = m_Manager.FindByEmail(ex.Email);

                if (m_Actual != null)
                {
                    m_Actual.UserName = ex.Username;
                    m_Actual.Email = ex.Email;

                    if (ex.IsAdministrator)
                    {
                        if (m_Manager.IsInRole(m_Actual.Id, "Administrator") == false)
                            m_Manager.AddToRole(m_Actual.Id, "Administrator");
                    }
                    else
                    {
                        if (m_Manager.IsInRole(m_Actual.Id, "Administrator"))
                            m_Manager.RemoveFromRole(m_Actual.Id, "Administrator");
                    }

                    var result = m_Manager.Update(m_Actual);

                    if (result.Succeeded)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
        }
        #endregion
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
