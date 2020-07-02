using System;
using System.Collections.Generic;
using System.Text;

namespace Projekat.Domain
{
   public class Rate : Entity
    {
        public float Number { get; set; }
        public int IdUser { get; set; }
        public int IdPost { get; set; }
        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }
}
