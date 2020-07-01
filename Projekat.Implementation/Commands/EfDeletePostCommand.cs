using System;
using System.Collections.Generic;
using System.Text;
using Projekat.Application.Commands;
using Projekat.Application.Exceptions;
using Projekat.Domain;
using Projekat.EfDataAccess;

namespace Projekat.Implementation.Commands
{
    public class EfDeletePostCommand : IDeletePostCommand
    {
        private readonly ProjekatContext _context;
        public EfDeletePostCommand(ProjekatContext context)
        {
            _context = context;
        }
        public int Id => 5;

        public string Name => "Delete post using Ef";

        public void Execute(int request)
        {
            var post = _context.Posts.Find(request);
            if(post == null)
            {
                throw new EntityNotFoundException(request,typeof(Post));
            }
            //_context.Posts.Remove(post);
            post.DeletedAt = DateTime.Now;
            post.IsActive = false;
            post.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
