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

namespace TeknoBlog.Admin.Delete
{
    public partial class _User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NameValueCollection m_Query = Request.QueryString;

            if (m_Query.HasKeys())
            {
                var m_ID = m_Query.Get("ID");

                using(ApplicationDbContext m_Context = new ApplicationDbContext())
                {
                    var m_Manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(m_Context));

                    ApplicationUser m_User = m_Manager.FindById(m_ID);

                    if (m_User != null)
                    {
                        m_Manager.Delete(m_User);

                    }
                }
            }

            Response.Redirect(Request.UrlReferrer.ToString());
        }
    }
}