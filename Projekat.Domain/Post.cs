﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Projekat.Domain
{
    public class Post : Entity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public int PictureId { get; set; }
        public virtual Picture Picture { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public float AverageRate { get; set; }
        public virtual ICollection<CategoryPost> CategoryPost { get; set; } = new HashSet<CategoryPost>();
        

    }
}
