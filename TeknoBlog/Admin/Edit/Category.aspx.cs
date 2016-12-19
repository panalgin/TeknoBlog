using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeknoBlog.Admin.Edit
{
    public partial class _Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                NameValueCollection m_Query = this.Request.QueryString;

                if (m_Query.HasKeys())
                {
                    int m_ID = Convert.ToInt32(m_Query.Get("ID"));

                    if (m_ID > 0)
                    {
                        using (BlogEntities m_Context = new BlogEntities())
                        {
                            Category m_Category = m_Context.Categories.Where(q => q.ID == m_ID).FirstOrDefault();

                            if (m_Category != null)
                            {
                                this.Name_Box.Text = m_Category.Name;
                            }
                            else
                                Response.Redirect("~/Admin/Categories");
                        }
                    }
                    else
                        Response.Redirect("~/Admin/Categories");
                }
                else
                    Response.Redirect("~/Admin/Categories");


            }
        }

        protected void Save_Button_Click(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                NameValueCollection m_Query = this.Request.QueryString;

                if (m_Query.HasKeys())
                {
                    int m_ID = Convert.ToInt32(m_Query.Get("ID"));

                    Page.Validate();

                    if (Page.IsValid && m_ID > 0)
                    {
                        using (BlogEntities m_Context = new BlogEntities())
                        {
                            Category m_Category = m_Context.Categories.Where(q => q.ID == m_ID).FirstOrDefault();

                            if (m_Category != null)
                            {
                                m_Category.Name = this.Name_Box.Text;
                                m_Context.SaveChanges();
                            }
                            else
                                Response.Redirect("~/Admin/Categories");
                        }
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