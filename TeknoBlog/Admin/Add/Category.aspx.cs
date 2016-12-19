using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeknoBlog.Models;

namespace TeknoBlog.Admin.Add
{
    public partial class _Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                this.Info.Visible = false;
        }

        protected void Save_Button_Click(object sender, EventArgs e)
        {
            if (this.Name_Box.Text.Length > 0)
            {
                Page.Validate();

                if (Page.IsValid)
                {
                    using (BlogEntities m_Context = new BlogEntities())
                    {
                        Category m_Category = new Category();
                        m_Category.Name = this.Name_Box.Text;
                        m_Context.Categories.Add(m_Category);
                        m_Context.SaveChanges();
                    }
                }
            }
        }

        protected void Validator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length < 3)
            {
                this.Validator.ErrorMessage = "En az 3 karakterden oluşan bir kategori adı girmelisiniz.";
                args.IsValid = false;
            }

            using (BlogEntities m_Context = new BlogEntities())
            {
                if (m_Context.Categories.Where(q => q.Name == args.Value).FirstOrDefault() == null)
                {
                    args.IsValid = true;
                }
                else
                {
                    this.Validator.ErrorMessage = "Böyle bir kategori zaten mevcut.";
                    args.IsValid = false;
                }
            }

            if (!args.IsValid)
                this.Info.Visible = false;
            else
                this.Info.Visible = true;
        }
    }
}