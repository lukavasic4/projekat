using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Projekat.Application.Commands;
using Projekat.Application.DataTransfer;
using Projekat.Application.Email;
using Projekat.EfDataAccess;
using Projekat.Implementation.Validation;

namespace Projekat.Implementation.Commands
{
    public class EfRegisterUserCommand : IRegisterUserCommand
    {
        private readonly ProjekatContext _context;
        private readonly RegisterUserValidator _validator;
        private readonly IEmailSender _sender;
        public EfRegisterUserCommand(ProjekatContext context, RegisterUserValidator validator, IEmailSender sender)
        {
            _context = context;
            _validator = validator;
            _sender = sender;
        }

        public int Id => 15;

        public string Name => "User Registration";

        public void Execute(RegisterUserDto request)
        {
            _validator.ValidateAndThrow(request);
            _context.Users.Add(new Domain.User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                Username = request.Username
            });
            _context.SaveChanges();
            _sender.Send(new SendEmailDto
            {
                Content = "<h1>Successfuly registration</h1>",
                SendTo = request.Email,
                Subject = "Registration"
            });
        }
    }
}
