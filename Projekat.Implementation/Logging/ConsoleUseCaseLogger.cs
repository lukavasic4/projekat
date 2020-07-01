using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Projekat.Application;

namespace Projekat.Implementation.Logging
{
    public class ConsoleUseCaseLogger : IUseCaseLogger
    {
        public void Log(IUseCase useCase, IApplicationActor actor, object data)
        {
            Console.WriteLine($"{DateTime.Now}: {actor.Indenty} is typing to execute {useCase.Name} using data:" + $"{JsonConvert.SerializeObject(data)}");
        }
    }
}
