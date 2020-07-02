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
        public int PictureId { get; set; }
        public int UserId { get; set; }
       
        public virtual ICollection<Category> Category { get; set; } 
    }
}
