using System;
using System.Collections.Generic;
using System.Text;
using Projekat.Application.Commands;
using Projekat.Application.Exceptions;
using Projekat.Domain;
using Projekat.EfDataAccess;

namespace Projekat.Implementation.Commands
{
    public class EfDeleteCategoryCommand : IDeleteCategoryCommand
    {
        private readonly ProjekatContext _context;
        public EfDeleteCategoryCommand(ProjekatContext context)
        {
            _context = context;
        }
        public int Id => 2;

        public string Name => "Delete category using Ef";

        public void Execute(int request)
        {
            var category = _context.Categories.Find(request);
            if(category == null)
            {
                throw new EntityNotFoundException(request,typeof(Category));
            }
            category.DeletedAt = DateTime.Now;
            category.IsDeleted = true;
            category.IsActive = false;
            _context.SaveChanges();
        }
    }
}
