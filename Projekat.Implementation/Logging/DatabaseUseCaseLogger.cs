using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Projekat.Application;
using Projekat.EfDataAccess;

namespace Projekat.Implementation.Logging
{
    public class DatabaseUseCaseLogger : IUseCaseLogger
    {
        private readonly ProjekatContext _context;

        public DatabaseUseCaseLogger(ProjekatContext context)
        {
            _context = context;
        }

        public void Log(IUseCase useCase, IApplicationActor actor, object useCaseData)
        {
            _context.UseCaseLogs.Add(new Domain.UseCaseLog
            {
                Actor = actor.Indenty,
                Data = JsonConvert.SerializeObject(useCaseData),
                Date = DateTime.UtcNow,
                UseCaseName = useCase.Name
            });
            _context.SaveChanges();
        }
    }
}
