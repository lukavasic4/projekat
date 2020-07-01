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
    public class EfModifyUserCommand : IModifyUserCommand
    {
        private readonly ProjekatContext _context;
        private readonly ModifyUserValidation _validator;
        public EfModifyUserCommand(ProjekatContext context, ModifyUserValidation validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => 11;

        public string Name =>"Modify user using Ef";

        void ICommandUpdate<UserDto,int>. Execute(UserDto request, int id)
        {
            _validator.ValidateAndThrow(request);
            var user = _context.Users.Find(id);
            if(user == null)
            {  
                throw new EntityNotFoundException(id, typeof(User));       
            }
        
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Password = request.Password;
            user.Username = request.Username;
            _context.SaveChanges();
        }
    }
}
