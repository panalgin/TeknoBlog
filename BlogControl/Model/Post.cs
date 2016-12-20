using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogControl.Model
{
    public class Post
    {
        public int ID { get; set; }
        public string Data { get; set; }
        public string AuthorID { get; set; }
        public DateTime CreatedAt { get; set; }

        public string Caption { get; set; }
        public int CategoryID { get; set; }
    }
}
