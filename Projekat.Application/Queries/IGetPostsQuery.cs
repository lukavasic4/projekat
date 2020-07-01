using System;
using System.Collections.Generic;
using System.Text;
using Projekat.Application.DataTransfer;
using Projekat.Application.Searches;

namespace Projekat.Application.Queries
{
    public interface IGetPostsQuery : IQuery<PostSearch,PagedResponse<PostDto>>
    {
    }
}
