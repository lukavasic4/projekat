using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekat.Application;
using Projekat.Application.Commands;
using Projekat.Application.DataTransfer;
using Projekat.EfDataAccess;

namespace Projekat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public CommentController(UseCaseExecutor executor)
        {
            _executor = executor;
        }
        // POST: api/Comment
        [HttpPost]
        public void Post([FromBody] CommentDto dto,
            [FromServices] ICreateCommentCommand command)
        {
            _executor.ExecuteCommand(command, dto);
        }

        // PUT: api/Comment/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CommentDto dto,
            [FromServices] IModifyCommentCommand command )
        {
            _executor.ExecuteCommandUpdate(command, dto, id);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeleteCommentCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
