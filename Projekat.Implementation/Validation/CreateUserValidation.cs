using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using Projekat.Application.DataTransfer;
using Projekat.EfDataAccess;

namespace Projekat.Implementation.Validation
{
    public class CreateUserValidation : AbstractValidator<UserDto>
    {
        public CreateUserValidation(ProjekatContext context)
        {
            RuleFor(x => x.FirstName)
                .MinimumLength(2)
                .NotEmpty()
                .WithMessage("The Field FirstName must not be empty");

            RuleFor(x => x.LastName)
               .MinimumLength(2)
               .NotEmpty()
               .WithMessage("The Field LastName must not be empty");

            RuleFor(x => x.Email)
               .NotEmpty()
               .WithMessage("The Field Email must not be empty")
               .Must(x => !context.Users.Any(user => user.Email == x))
               .WithMessage("Username is alredy taken")
               .EmailAddress();

            RuleFor(x => x.Password)
               .MinimumLength(2)
               .NotEmpty()
               .WithMessage("The Field Password must not be empty");

            RuleFor(x => x.Username)
               .NotEmpty()
               .WithMessage("The Field Username must not be empty")
               .Must(x => !context.Users.Any(user => user.Username == x))
               .WithMessage("Username is alredy taken");
        }
    }
}
