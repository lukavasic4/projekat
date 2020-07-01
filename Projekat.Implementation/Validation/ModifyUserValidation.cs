using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using Projekat.Application.DataTransfer;
using Projekat.EfDataAccess;

namespace Projekat.Implementation.Validation
{
    public class ModifyUserValidation : AbstractValidator<UserDto>
    {
        public ModifyUserValidation(ProjekatContext context)
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("FirstName is required parametar");

            RuleFor(x => x.LastName)
               .NotEmpty()
               .WithMessage("LastName is required parametar");

            RuleFor(x => x.Email)
               .NotEmpty()
               .WithMessage("Email is required parametar")
               .Must(x => !context.Users.Any(user => user.Email == x))
                .WithMessage("Email is alredy taken");


            RuleFor(x => x.Password)
              .NotEmpty()
              .WithMessage("Email is required parametar");

            RuleFor(x => x.Username)
              .NotEmpty()
              .WithMessage("Email is required parametar")
              .Must(x => !context.Users.Any(user => user.Username == x))
              .WithMessage("Username is alredy taken");


        }
    }
}
