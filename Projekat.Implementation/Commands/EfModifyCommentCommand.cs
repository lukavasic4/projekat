using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Projekat.Application;
using Projekat.Application.Commands;
using Projekat.Application.DataTransfer;
using Projekat.Application.Exceptions;
using Projekat.Domain;
using Projekat.EfDataAccess;
using Projekat.Implementation.Validation;

namespace Projekat.Implementation.Commands
{
    public class EfModifyCommentCommand : IModifyCommentCommand
    {
        private readonly ProjekatContext _context;
        private readonly ModifyCommentValidation _validator;

        public EfModifyCommentCommand(ProjekatContext context, ModifyCommentValidation validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 17;

        public string Name => "Modify comment using Ef";

        void ICommandUpdate<CommentDto, int>.Execute(CommentDto request, int id)
        {
            _validator.ValidateAndThrow(request);
            var comment = _context.Comments.Find(id);
            if (comment == null)
            {
                throw new EntityNotFoundException(id, typeof(Comment));
            };
            comment.TextComment = request.TextComment;
            comment.PostId = request.PostId;
            comment.UserId = request.UserId;
            _context.SaveChanges();
        }
    }
}
