using System;
using System.Collections.Generic;
using System.Text;
using Projekat.Domain;

namespace Projekat.Application.DataTransfer
{
    public class PostDto
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public int IdPicture { get; set; }
        public int IdUser { get; set; }
        public virtual ICollection<Category> Category { get; set; } 
    }
}
