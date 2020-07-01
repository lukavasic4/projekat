using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Projekat.Application.DataTransfer
{
   public class PictureDto
    {
        public IFormFile Image { get; set; }
        public IFormFile Alt { get; set; }
    }
}
