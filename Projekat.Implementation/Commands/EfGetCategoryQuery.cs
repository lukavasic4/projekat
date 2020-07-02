using System;
using System.Collections.Generic;
using System.Text;
using Projekat.Application.Commands;
using Projekat.Application.DataTransfer;
using Projekat.Application.Exceptions;
using Projekat.Domain;
using Projekat.EfDataAccess;

namespace Projekat.Implementation.Commands
{
    public class EfGetCategoryQuery : IGetCategoryQuery
    {
        private readonly ProjekatContext _context;

        public EfGetCategoryQuery(ProjekatContext context)
        {
            _context = context;
        }        
        public int Id => 9;

        public string Name =>"Get category using Ef";


        public CategoryDto Execute(int search)
        {
            var category = _context.Categories.Find(search);
            if (category == null)
            {
                throw new EntityNotFoundException(search, typeof(Category));
            }
            var response = new CategoryDto
            {
                Name = category.Name
            };
            return response;
        }
    }
}
