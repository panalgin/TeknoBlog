using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeknoBlog.Admin.Edit
{
    public partial class _Content : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Data_Box.ValidateRequestMode = ValidateRequestMode.Disabled;

            if (!this.IsPostBack)
            {
                using (BlogEntities m_Context = new BlogEntities())
                {
                    var m_Categories = m_Context.Categories.ToList();
                    this.Category_Combo.DataSource = m_Categories;
                    this.Category_Combo.DataTextField = "Name";
                    this.Category_Combo.DataValueField = "ID";
                    this.Category_Combo.DataBind();
                }

                NameValueCollection m_Query = this.Request.QueryString;

                if (m_Query.HasKeys())
                {
                    int m_ID = Convert.ToInt32(m_Query.Get("ID"));

                    if (m_ID > 0)
                    {
                        using (BlogEntities m_Context = new BlogEntities())
                        {
                            Post m_Post = m_Context.Posts.Where(q => q.ID == m_ID).FirstOrDefault();

                            if (m_Post != null)
                            {
                                this.Name_Box.Text = m_Post.Caption;
                                this.Category_Combo.Items.FindByValue(m_Post.CategoryID.ToString()).Selected = true;
                                this.Data_Box.InnerHtml = m_Post.Data;
                            }
                            else
                                Response.Redirect("~/Admin/Contents");
                        }
                    }
                    else
                        Response.Redirect("~/Admin/Contents");
                }
                else
                    Response.Redirect("~/Admin/Contents");
            }
        }

        protected void Validator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length < 3)
            {
                this.Validator.ErrorMessage = "En az 3 karakterden oluşan bir başlık girmelisiniz.";
                args.IsValid = false;
            }
            else
                args.IsValid = true;

            if (!args.IsValid)
                this.Info.Visible = false;
        }

        protected void Save_Button_Click(object sender, EventArgs e)
        {
            NameValueCollection m_Query = this.Request.QueryString;

            if (m_Query.HasKeys())
            {
                int m_ID = Convert.ToInt32(m_Query.Get("ID"));

                if (m_ID > 0)
                {
                    Page.Validate();

                    if (Page.IsValid)
                    {
                        using (BlogEntities m_Context = new BlogEntities())
                        {
                            Post m_Post = m_Context.Posts.Where(q => q.ID == m_ID).FirstOrDefault();

                            if (m_Post != null)
                            {
                                m_Post.Caption = this.Name_Box.Text;
                                m_Post.CategoryID = Convert.ToInt32(this.Category_Combo.SelectedValue);
                                m_Post.Data = this.Data_Box.InnerHtml;

                                m_Context.SaveChanges();
                                this.Info.Visible = true;
                            }
                            else
                                Response.Redirect("~/Admin/Contents");
                        }
                    }
                }
            }
        }
    }
}