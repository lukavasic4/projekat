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
    public class EfGetUserQuery : IGetUserQuery
    {
        private readonly ProjekatContext _context;
        public EfGetUserQuery(ProjekatContext context)
        {
            _context = context;
        }
        public int Id =>12;

        public string Name => "Get user using Ef";

        public UserDto Execute(int search)
        {
            var user = _context.Users.Find(search);
            if (user == null)
            {
                throw new EntityNotFoundException(search, typeof(User));
            }
            var response = new UserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Username = user.Username
            };
            return response;
        }
    }
}
