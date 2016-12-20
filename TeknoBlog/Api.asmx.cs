using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

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
    }
}
