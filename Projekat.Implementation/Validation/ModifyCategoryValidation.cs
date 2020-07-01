using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using Projekat.Application.DataTransfer;
using Projekat.EfDataAccess;

namespace Projekat.Implementation.Validation
{
    public class ModifyCategoryValidation : AbstractValidator<CategoryDto>
    {
        public ModifyCategoryValidation(ProjekatContext context)
        {
            RuleFor(x => x.Name)
              .NotEmpty()
              .WithMessage("Name of category not be empty")
              .Must(x => !context.Categories.Any(category => category.Name == x))
              .WithMessage("Name is alredy taken");
        }
    }
}
