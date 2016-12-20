using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TeknoBlog.Controllers
{
    public class ContentController : ApiController
    {
        public IEnumerable<Post> GetAllPosts()
        {
            List<Post> posts = new List<Post>();

            using(BlogEntities m_Context = new BlogEntities())
            {
                posts = m_Context.Posts.ToList();
            }

            return posts;
        }

        public IHttpActionResult GetPost(int id)
        {
            Post m_Post = null;

            using (BlogEntities m_Context = new BlogEntities())
            {
                m_Post = m_Context.Posts.Where(q => q.ID == id).FirstOrDefault();
            }

            if (m_Post == null)
                return NotFound();
            else
                return Ok(m_Post);
        }
    }
}
