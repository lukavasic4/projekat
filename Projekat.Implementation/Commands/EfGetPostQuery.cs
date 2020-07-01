using System;
using System.Collections.Generic;
using System.Text;
using Projekat.Application.Commands;
using Projekat.Application.DataTransfer;
using Projekat.Application.Exceptions;
using Projekat.Domain;
using Projekat.EfDataAccess;

namespace Projekat.Implementation.Commands
{
    public class EfGetPostQuery : IGetPostQuery
    {
        private readonly ProjekatContext _context;
        public EfGetPostQuery(ProjekatContext context)
        {
            _context = context;
        }
        public int Id => 7;

        public string Name => "Get one post";

        public PostDto Execute(int request)
        {
            var post = _context.Posts.Find(request);
            if (post == null)
            {
                throw new EntityNotFoundException(request, typeof(Post));
            }
            var response = new PostDto
            {
                Text = post.Text,
                Title = post.Title,
                IdPicture = post.IdPicture,
                IdUser = post.IdUser
            };
            return response;
        }
    }
}
