using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeknoBlog.Models
{
    public class UserEx
    {
        public string ID { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public bool IsAdministrator { get; set; }
        public string Password { get; set; }

        public static UserEx CopyFrom(ApplicationUser user)
        {
            UserEx m_UserEx = null;

            using (ApplicationDbContext m_Context = new ApplicationDbContext())
            {
                var m_Manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(m_Context));

                m_UserEx = new UserEx();
                m_UserEx.ID = user.Id;
                m_UserEx.Email = user.Email;
                m_UserEx.Username = user.UserName;
                m_UserEx.IsAdministrator = m_Manager.IsInRole(user.Id, "Administrator");

            }

            return m_UserEx;
        }
    }
}