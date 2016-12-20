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

namespace TeknoBlog.Admin.Edit
{
    public partial class _User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NameValueCollection m_Query = Request.QueryString;

            if (m_Query.HasKeys())
            {
                var m_ID = m_Query.Get("ID");

                using (ApplicationDbContext m_Context = new ApplicationDbContext())
                {
                    var m_Manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(m_Context));

                    ApplicationUser m_User = m_Manager.FindById(m_ID);

                    if (m_User != null)
                    {
                        this.Email_Label.InnerText = m_User.Email;

                        if (m_Manager.IsInRole(m_User.Id, "Administrator"))
                        {
                            this.IsAdministrator_Check.Checked = true;
                        }
                    }
                }
            }

            if (!this.IsPostBack)
                this.Info.Visible = false;
        }

        protected void Save_Button_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                NameValueCollection m_Query = Request.QueryString;

                if (m_Query.HasKeys())
                {
                    var m_ID = m_Query.Get("ID");

                    using (ApplicationDbContext m_Context = new ApplicationDbContext())
                    {
                        var m_Manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(m_Context));

                        ApplicationUser m_User = m_Manager.FindById(m_ID);
                        IdentityRole m_Admin = m_Context.Roles.Where(q => q.Name == "Administrator").FirstOrDefault();

                        if (m_User != null)
                        {
                            if (this.IsAdministrator_Check.Checked)
                            {
                                if (!m_Manager.IsInRole(m_User.Id, m_Admin.Name))
                                    m_Manager.AddToRole(m_User.Id, m_Admin.Name);
                            }
                            else
                            {
                                if (m_Manager.IsInRole(m_User.Id, m_Admin.Name))
                                    m_Manager.RemoveFromRole(m_User.Id, m_Admin.Name);
                            }

                            this.Info.Visible = true;
                        }
                    }
                }
            }
        }
    }
}