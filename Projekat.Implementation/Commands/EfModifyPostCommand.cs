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
    public class EfModifyPostCommand : IModifyPostCommand
    {
        private readonly ProjekatContext _context;
        private readonly ModifyPostValidation _validator;
        public EfModifyPostCommand(ProjekatContext context, ModifyPostValidation validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 6;

        public string Name =>"Modify post using Ef";

        void ICommandUpdate<PostDto,int>.Execute(PostDto request, int id)
        {
            _validator.ValidateAndThrow(request);
            var post = _context.Posts.Find(id);
            if (post == null)
            {
                throw new EntityNotFoundException(id, typeof(User));
            }
            post.Title = request.Title;
            post.Text = request.Text;
            _context.SaveChanges();
        }
    }
}
