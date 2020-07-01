using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using FluentValidation;
using Projekat.Application.DataTransfer;
using Projekat.EfDataAccess;

namespace Projekat.Implementation.Validation
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserValidator(ProjekatContext context)
        {
            RuleFor(x => x.FirstName)
                .NotEmpty();

            RuleFor(x => x.LastName)
               .NotEmpty();

            RuleFor(x => x.Password)
               .NotEmpty()
               .MinimumLength(6);

            RuleFor(x => x.Username)
                 .NotEmpty()
                 .MinimumLength(4)
                 .Must(x => !context.Users.Any(user => user.Username == x))
                 .WithMessage("Username is alredy taken");

            RuleFor(x => x.Email)
               .NotEmpty()
               .EmailAddress()
               .Must(x => !context.Users.Any(user => user.Email == x))
               .WithMessage("Email is alredy taken");
        }
    }
}
