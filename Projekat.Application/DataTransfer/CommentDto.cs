using System;
using System.Collections.Generic;
using System.Text;

namespace Projekat.Application.DataTransfer
{
    public class CommentDto
    {
        public string TextComment { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
    }
}
