using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using TeknoBlog.Models;

namespace TeknoBlog.Admin
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (ApplicationDbContext m_AspnetContext = new ApplicationDbContext())
            {
                var m_Users = m_AspnetContext.Users.ToList();

                m_Users.All(delegate (ApplicationUser user)
                {
                    List<string> m_Roles = new List<string>();

                    user.Roles.All(delegate (IdentityUserRole role)
                    {
                        m_Roles.Add(m_AspnetContext.Roles.Where(q => q.Id == role.RoleId).FirstOrDefault().Name);
                        return true;
                    });

                    string m_Role = string.Join(",", m_Roles.ToArray());

                    this.Table_Body.InnerHtml += string.Format("<tr>" +
                                                                    "<td>{0}</td>" +
                                                                    "<td>{1}</td>" +
                                                                    "<td><a href=\"/Admin/Edit/User?ID={2}\">Düzenle</a> - <a href=\"/Admin/Delete/User?ID={2}\">Sil</a></td>" +
                                                                 "</tr>", user.UserName, m_Role, user.Id);
                    return true;
                });
            }
        }
    }
}