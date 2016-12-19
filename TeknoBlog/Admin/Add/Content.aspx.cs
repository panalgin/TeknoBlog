using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeknoBlog.Admin.Add
{
    public partial class _Content : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

        }

        protected void Save_Button_Click(object sender, EventArgs e)
        {

        }
    }
}