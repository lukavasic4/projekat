using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using Projekat.Application.DataTransfer;
using Projekat.EfDataAccess;

namespace Projekat.Implementation.Validation
{
    public class ModifyPostValidation : AbstractValidator<PostDto>
    {
        private readonly ProjekatContext _context;
        public ModifyPostValidation(ProjekatContext context)
        {
            _context = context;
        }
        public ModifyPostValidation()
        {
            RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("title not be empty")
            .Must(x => !_context.Posts.Any(user => user.Title == x))
             .WithMessage("Username is alredy taken");


            RuleFor(x => x.Text)
            .NotEmpty()
            .WithMessage("title not be empty");
        }
    }
}
