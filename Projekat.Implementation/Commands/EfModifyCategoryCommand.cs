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
    public class EfModifyCategoryCommand : IModifyCategoryCommand
    {
        private readonly ProjekatContext _context;
        private readonly ModifyCategoryValidation _validator;

        public EfModifyCategoryCommand(ProjekatContext context, ModifyCategoryValidation validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 3;

        public string Name => "Modify category";

        void ICommandUpdate<CategoryDto,int>.Execute(CategoryDto request, int id)
        {
            _validator.ValidateAndThrow(request);
            var category = _context.Categories.Find(id);
            if(category == null)
            {
               throw new EntityNotFoundException(id, typeof(Category));
            }
            category.Name = request.Name;
            _context.SaveChanges();
        }

       
    }
}
