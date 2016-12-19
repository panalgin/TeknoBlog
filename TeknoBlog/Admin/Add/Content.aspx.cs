using Microsoft.AspNet.Identity;
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
    public partial class _Content : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Data_Box.ValidateRequestMode = ValidateRequestMode.Disabled;

            using (BlogEntities m_Context = new BlogEntities()) {
                var m_Categories = m_Context.Categories.ToList();
                this.Category_Combo.DataSource = m_Categories;
                this.Category_Combo.DataTextField = "Name";
                this.Category_Combo.DataValueField = "ID";
                this.Category_Combo.DataBind();
            }
        }

        protected void Validator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length < 3)
            {
                this.Validator.ErrorMessage = "En az 3 karakterden oluşan bir başlık girmelisiniz.";
                args.IsValid = false;
            }

            using (BlogEntities m_Context = new BlogEntities())
            {
                if (m_Context.Posts.Where(q => q.Caption == args.Value).FirstOrDefault() == null)
                {
                    args.IsValid = true;
                }
                else
                {
                    this.Validator.ErrorMessage = "Bu adla eklemiş olduğunuz bir içerik zaten mevcut.";
                    args.IsValid = false;
                }
            }

            if (!args.IsValid)
                this.Info.Visible = false;
        }

        protected void Save_Button_Click(object sender, EventArgs e)
        {
            if (this.Name_Box.Text.Length > 0)
            {
                Page.Validate();

                if (Page.IsValid)
                {
                    ApplicationDbContext m_AspnetContext = new ApplicationDbContext();
                    var m_Manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(m_AspnetContext));

                    var m_Author = m_Manager.FindByName(HttpContext.Current.User.Identity.GetUserName());

                    using (BlogEntities m_Context = new BlogEntities())
                    {
                        Post m_Post = new Post();
                        m_Post.AuthorID = m_Author.Id;
                        m_Post.Caption = this.Name_Box.Text;
                        m_Post.CreatedAt = DateTime.Now;
                        m_Post.CategoryID = Convert.ToInt32(this.Category_Combo.SelectedValue);
                        m_Post.Data = this.Data_Box.InnerHtml;

                        m_Context.Posts.Add(m_Post);
                        m_Context.SaveChanges();

                        this.Info.Visible = true;
                    }
                }
            }
        }
    }
}