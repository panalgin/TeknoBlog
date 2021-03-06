﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeknoBlog.Models;

namespace TeknoBlog.Admin.Add
{
    public partial class _User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                this.Info.Visible = false;
        }

        protected void Create_User_Button_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using(ApplicationDbContext m_Context = new ApplicationDbContext())
                {
                    var m_Manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(m_Context));

                    ApplicationUser m_User = new ApplicationUser();
                    m_User.UserName = this.Email.Text;
                    m_User.Email = this.Email.Text;

                    var result = m_Manager.Create(m_User, this.Password.Text);

                    if (result.Succeeded)
                    {
                        this.Info.Visible = true;
                    }
                }
            }
        }
    }
}