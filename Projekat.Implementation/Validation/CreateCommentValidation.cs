using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Projekat.Application.DataTransfer;
using Projekat.EfDataAccess;

namespace Projekat.Implementation.Validation
{
    public class CreateCommentValidation : AbstractValidator<CommentDto>
    {
        public CreateCommentValidation(ProjekatContext c)
        {
            RuleFor(x => x.TextComment)
                .NotEmpty()
                .WithMessage("Text of comment not be empty");
            RuleFor(x => x.PostId)
                .NotNull()
                .WithMessage("IdPost not be null");
            RuleFor(x => x.UserId)
                .NotNull()
                .WithMessage("IdUser not be null");

        }
    }
}
