using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using Projekat.Application.DataTransfer;
using Projekat.EfDataAccess;

namespace Projekat.Implementation.Validation
{
    public class CreatePostValidation : AbstractValidator<PostDto>
    {
        public CreatePostValidation(ProjekatContext context)
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MinimumLength(3)
                .Must(x => !context.Posts.Any(c => c.Title == x))
                .WithMessage("Title must be unique");

            RuleFor(x => x.Text)
                .NotEmpty()
                .MinimumLength(6)
                .WithMessage("You must not enter less than 6 characters");

        }
    }
}
