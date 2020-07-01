using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projekat.Application;

namespace Projekat.Api.Core
{
    public class AnonymousActor : IApplicationActor
    {
        public int Id => 0;

        public string Indenty => "Anonymus";

        public IEnumerable<int> AllowedUseCases => new List<int> { 15 };
    }
}
