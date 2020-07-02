using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Projekat.Application.Exceptions;

namespace Projekat.Application
{
    public class UseCaseExecutor
    {
        private readonly IApplicationActor actor;
        private readonly IUseCaseLogger logger;
        public UseCaseExecutor(IApplicationActor actor, IUseCaseLogger logger)
        {
            this.actor = actor;
            this.logger = logger;
        }
        public void ExecuteCommand<TRequest>(ICommand<TRequest> command,TRequest request)
        {
            logger.Log(command, actor, request);
            if (!actor.AllowedUseCases.Contains(command.Id))
            {
                throw new UnauthorizedUseCaseException(command, actor);
            }
            command.Execute(request);
        }
        public void ExecuteCommandUpdate<TRequest>(ICommandUpdate<TRequest, int>command, TRequest request, int id)
        {
            logger.Log(command, actor, id);
            if (!actor.AllowedUseCases.Contains(command.Id))
            {
                throw new UnauthorizedUseCaseException(command, actor);
            }
            command.Execute(request, id);
        }
        public void ExecuteCommandRate<TRequest>(ICommandRate<TRequest, int> command, TRequest request, int id)
        {
            logger.Log(command, actor, id);
            if (!actor.AllowedUseCases.Contains(command.Id))
            {
                throw new UnauthorizedUseCaseException(command, actor);
            }
            command.Execute(request, id);
        }
        public TResult ExecuteQuery<TSearch,TResult>(IQuery<TSearch,TResult>query,TSearch search)
        {
            logger.Log(query, actor,search);
            if (!actor.AllowedUseCases.Contains(query.Id))
            {
                throw new UnauthorizedUseCaseException(query, actor);
            }
            return query.Execute(search);
        }
    }
}
