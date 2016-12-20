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
    public partial class Edit_Category_Pop : Form
    {
        public Category Category { get; set; }

        public Edit_Category_Pop()
        {
            InitializeComponent();
        }

        private void Edit_Category_Pop_Load(object sender, EventArgs e)
        {
            this.Name_Box.Text = this.Category.Name;
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            using(ApiSoapClient m_Client = new ApiSoapClient())
            {
                this.Category.Name = this.Name_Box.Text;
                var result = m_Client.UpdateCategory(this.Category);

                this.Close();
            }
        }
    }
}
