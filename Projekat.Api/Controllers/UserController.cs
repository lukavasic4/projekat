using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekat.Application;
using Projekat.Application.Commands;
using Projekat.Application.DataTransfer;

namespace Projekat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly IApplicationActor _actor;
        public UserController(UseCaseExecutor executor, IApplicationActor actor)
        {
            _executor = executor;
            _actor = actor;
        }
        
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get1")]
        public IActionResult Get(int id,[FromServices] IGetUserQuery query)
        {
            return Ok(_executor.ExecuteQuery(query,id));
        }

        // POST: api/User
        [Authorize]
        [HttpPost]
        public void Post([FromBody] UserDto dto,
            [FromServices] ICreateUserCommand command)
        {
            _executor.ExecuteCommand(command, dto);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserDto dto,
            [FromServices] IModifyUserCommand command)
        {
            _executor.ExecuteCommandUpdate(command, dto, id);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeleteUserCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
