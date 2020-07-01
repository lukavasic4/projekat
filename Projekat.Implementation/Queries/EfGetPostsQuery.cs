using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projekat.Application.Commands;
using Projekat.Application.DataTransfer;
using Projekat.Application.Queries;
using Projekat.Application.Searches;
using Projekat.EfDataAccess;

namespace Projekat.Implementation.Queries
{
    public class EfGetPostsQuery : IGetPostsQuery
    {
        private readonly ProjekatContext _context;
        public EfGetPostsQuery(ProjekatContext context)
        {
            _context = context;
        }
        public int Id => 4;

        public string Name => "Post search using Ef";

        public PagedResponse<PostDto> Execute(PostSearch search)
        {
            var query = _context.Posts.AsQueryable();
            if (!string.IsNullOrEmpty(search.Title) || !string.IsNullOrWhiteSpace(search.Title))
            {
                query = query.Where(x => x.Title.ToLower().Contains(search.Title.ToLower()));
            }
            var skipCount = search.PerPage * (search.Page - 1);
            var response = new PagedResponse<PostDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new PostDto
                {
                    Title = x.Title
                }).ToList()
            };
            return response;
        }
    }
}
