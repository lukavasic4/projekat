using System;
using System.Collections.Generic;
using System.Linq;
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
            var rates = _context.Rates.Where(x => x.IdPost == post.Id);
            var avg = rates.Select(x => x.Number).Average();
            var comment = _context.Comments.Where(x => x.PostId == post.Id);
            var user = _context.Users.Find(post.UserId);
            var response = new PostDto
            {
                Text = post.Text,
                Title = post.Title,
                PictureId = post.PictureId,
                UserId = post.UserId,
                
            };
            return response;
        }
    }
}
