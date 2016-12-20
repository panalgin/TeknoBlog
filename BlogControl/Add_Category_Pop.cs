using BlogControl.ApiService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlogControl
{
    public partial class Add_Category_Pop : Form
    {
        public Add_Category_Pop()
        {
            InitializeComponent();
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (this.Name_Box.Text.Length > 0)
            {
                using (ApiSoapClient m_Client = new ApiSoapClient())
                {
                    Category m_Category = new Category();
                    m_Category.Name = this.Name_Box.Text;

                    var result = m_Client.AddCategory(m_Category);

                    this.Close();
                }
            }
        }
    }
}
