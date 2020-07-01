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
    public class EfCreateUserCommand : ICreateUserCommand
    {
        private readonly ProjekatContext _context;
        private readonly CreateUserValidation _validator;
        public EfCreateUserCommand(ProjekatContext context, CreateUserValidation validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 8;

        public string Name => "Create user using Ef";

        void ICommand<UserDto>.Execute(UserDto request)
        {
            _validator.ValidateAndThrow(request);
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                Username = request.Username
            };
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
