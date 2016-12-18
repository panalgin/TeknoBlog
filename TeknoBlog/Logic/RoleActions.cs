using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeknoBlog.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TeknoBlog.Logic
{
    internal class RoleActions
    {
        internal void Initialize()
        {
            // Access the application context and create result variables.
            ApplicationDbContext context = new ApplicationDbContext();
            IdentityResult IdRoleResult;
            IdentityResult IdUserResult;

            // Create a RoleStore object by using the ApplicationDbContext object. 
            // The RoleStore is only allowed to contain IdentityRole objects.
            var roleStore = new RoleStore<IdentityRole>(context);

            // Create a RoleManager object that is only allowed to contain IdentityRole objects.
            // When creating the RoleManager object, you pass in (as a parameter) a new RoleStore object. 
            var roleMgr = new RoleManager<IdentityRole>(roleStore);

            if (!roleMgr.RoleExists("Administrator"))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole { Name = "Administrator" });
            }

            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            ApplicationUser m_Admin = userMgr.Users.FirstOrDefault();

            if (m_Admin != null)
            {
                if (!userMgr.IsInRole(m_Admin.Id, "Administrator"))
                {
                    IdUserResult = userMgr.AddToRole(m_Admin.Id, "Administrator");
                }
            }
        }
    }
}