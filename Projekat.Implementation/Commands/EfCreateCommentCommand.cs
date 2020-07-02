using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Projekat.Application.Commands;
using Projekat.Application.DataTransfer;
using Projekat.Domain;
using Projekat.EfDataAccess;
using Projekat.Implementation.Validation;

namespace Projekat.Implementation.Commands
{
   public class EfCreateCommentCommand : ICreateCommentCommand
    {
        private readonly ProjekatContext _context;
        private readonly CreateCommentValidation _validator;

        public EfCreateCommentCommand(ProjekatContext context, CreateCommentValidation validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 16;

        public string Name => "Create comment";

        public void Execute(CommentDto request)
        {
            _validator.ValidateAndThrow(request);
            var comment = new Comment
            {
                TextComment = request.TextComment,
                PostId = request.PostId,
                UserId = request.UserId
            };
            _context.Add(comment);
            _context.SaveChanges();
        }
    }
}
