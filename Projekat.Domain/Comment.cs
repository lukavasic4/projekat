using System;
using System.Collections.Generic;
using System.Text;

namespace Projekat.Domain
{
   public class Comment : Entity
    {
        public string TextComment { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }
}
