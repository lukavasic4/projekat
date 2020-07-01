using System;
using System.Collections.Generic;
using System.Text;

namespace Projekat.Application.Exceptions
{
    public class UnauthorizedUseCaseException : Exception
    {
        public UnauthorizedUseCaseException(IUseCase useCase, IApplicationActor actor) : base($"Actor with an id of{actor.Id} - {actor.Indenty} tryed to execute {useCase.Name}.")
        {

        }
    }
}
