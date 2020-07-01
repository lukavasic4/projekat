using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Projekat.Application;
using Projekat.Application.Commands;
using Projekat.Application.DataTransfer;
using Projekat.Domain;
using Projekat.EfDataAccess;
using Projekat.Implementation.Validation;

namespace Projekat.Implementation.Commands
{
    public class EfCreateCategoryCommand : ICreateCategoryCommand
    {
        private readonly ProjekatContext _context;
        private readonly CreateCategoryValidation _validator;
        public EfCreateCategoryCommand(ProjekatContext context, CreateCategoryValidation validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 1;
        public string Name => "Create group using Ef";

        public void Execute(CategoryDto request)
        {
            throw new NotImplementedException();
        }

        void ICommand<CategoryDto>.Execute(CategoryDto request)
        {
            _validator.ValidateAndThrow(request);
            var category = new Category
            {
                Name = request.Name
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
    }
}
