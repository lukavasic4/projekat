using System;
using System.Collections.Generic;
using System.Text;

namespace Projekat.Domain
{
    public class CategoryPost : Entity
    {
        public int IdCategory{ get; set; }
        public int IdPost { get; set; }
        public virtual Category Category { get; set; }
        public virtual Post Post { get; set; }
    }
}
