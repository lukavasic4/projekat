using System;
using System.Collections.Generic;
using System.Text;

namespace Projekat.Domain
{
    public class CategoryPost : Entity
    {
        public int CategoryId{ get; set; }
        public int PostId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Post Post { get; set; }
    }
}
