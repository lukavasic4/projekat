using System;
using System.Collections.Generic;
using System.Text;
using Projekat.Application.Commands;
using Projekat.Application.Exceptions;
using Projekat.Domain;
using Projekat.EfDataAccess;

namespace Projekat.Implementation.Commands
{
    public class EfDeleteCommentCommand : IDeleteCommentCommand
    {
        private readonly ProjekatContext _context;

        public EfDeleteCommentCommand(ProjekatContext context)
        {
            _context = context;
        }
        public int Id => 18;

        public string Name => "Delete comment using Ef";

        public void Execute(int request)
        {
            var comment = _context.Comments.Find(request);
            if(comment == null)
            {
                throw new EntityNotFoundException(request, typeof(Comment));
            }
            comment.DeletedAt = DateTime.Now;
            comment.IsDeleted = true;
            comment.IsActive = false;
            _context.SaveChanges();
        }
    }
}
