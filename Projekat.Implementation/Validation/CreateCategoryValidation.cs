using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using Projekat.Application.DataTransfer;
using Projekat.EfDataAccess;

namespace Projekat.Implementation.Validation
{
    public class CreateCategoryValidation : AbstractValidator<CategoryDto>
    {
        public CreateCategoryValidation(ProjekatContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Must(x => !context.Categories.Any(c => c.Name == x))
                .WithMessage("Name of category must be unique");
                
        }
    }
}
