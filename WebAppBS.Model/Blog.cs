using System;
using System.Collections.Generic;
using System.Text;

namespace WebAppBS.Model
{
   public class Blog
    {
        public int BlogID { get; set; }
        public string BlogContent { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }

        public int NumberOfComments { get; set; }

        public virtual List<Comments> Comments { get; set; }
    }
}
