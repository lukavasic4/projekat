using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projekat.Application;
using Projekat.Application.Commands;
using Projekat.Application.DataTransfer;
using Projekat.Domain;
using Projekat.EfDataAccess;

namespace Projekat.Implementation.Commands
{
    public class EfCreateRateCommand : IRatePostCommand
    {
        private readonly ProjekatContext _context;
        private readonly IApplicationActor _actor;

        public EfCreateRateCommand(ProjekatContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }

        public int Id => 19;

        public string Name => "Rate using Ef";

        public void Execute(RateDto request, int id)
        {
            var userPost = _context.Rates.Where(x => x.IdPost == request.IdPost).Select(x => x.IdUser);
            if(request.Number > 5)
            {
                throw new ArgumentException("Number must be under 6");
            }
            if (userPost.Contains(_actor.Id))
            {
                throw new ArgumentException("Voted");
            }
            var rate = new Rate
            {
                Number = request.Number,
                IdUser = _actor.Id,
                IdPost = id
            };
            _context.Rates.Add(rate);
            _context.SaveChanges();
        }
    }
}
