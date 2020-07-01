using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projekat.Application;

namespace Projekat.Api.Core
{
    public class JwtActor : IApplicationActor
    {
        public int Id  {get;set;}

        public string Indenty { get; set; }

        public IEnumerable<int> AllowedUseCases { get; set; }
    }
}
