using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebAppBS.Model
{
   public class LikeOrDisLikes
    {
        [Key]
        public int VoteID { get; set; }
        public bool LikeORDislike { get; set; }
        public int CommentsID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public virtual Comments Comments { get; set; }
    }
}
