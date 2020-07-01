using System;
using System.Collections.Generic;
using System.Text;
using Projekat.Application.Commands;
using Projekat.Application.Exceptions;
using Projekat.Domain;
using Projekat.EfDataAccess;

namespace Projekat.Implementation.Commands
{
    public class EfDeleteUserCommand : IDeleteUserCommand
    {
        private readonly ProjekatContext _context;
        public EfDeleteUserCommand(ProjekatContext context)
        {
            _context = context;
        }
        public int Id => 10;

        public string Name => "Delete user using Ef";

        public void Execute(int request)
        {
            var user = _context.Users.Find(request);
            if(user == null)
            {
                throw new EntityNotFoundException(request, typeof(User));
            }
            //_context.Users.Remove(user);
            user.DeletedAt = DateTime.Now;
            user.IsActive = false;
            user.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
