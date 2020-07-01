using System;
using System.Collections.Generic;
using System.Text;

namespace Projekat.Application
{
    public interface IApplicationActor
    {
        public int Id { get; }
        public string Indenty { get; }
        IEnumerable<int> AllowedUseCases { get; }
    }
}
