using System;
using System.Collections.Generic;
using System.Text;
using Projekat.Application.DataTransfer;

namespace Projekat.Application.Commands
{
    public interface IGetCategoryQuery : IQuery<int,CategoryDto>
    {
    }
}
