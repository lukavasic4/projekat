using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekat.Application;
using Projekat.Application.Commands;
using Projekat.Application.DataTransfer;
using Projekat.Application.Queries;
using Projekat.Application.Searches;

namespace Projekat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        public PostController(UseCaseExecutor executor)
        {
            _executor = executor;
        }
        // GET: api/Post
        [HttpGet]
        public IActionResult Get([FromQuery] PostSearch search,[FromServices] IGetPostsQuery query)
        {
            return Ok(query.Execute(search));
        }

        // GET: api/Post/5
        [HttpGet("{id}")]
        public IActionResult Get(int id,[FromServices] IGetPostQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST: api/Post
        [HttpPost]
        public void Post([FromBody] PostDto dto,
            [FromServices] ICreatePostCommand command)
        {
           _executor.ExecuteCommand(command, dto);
        }

        // PUT: api/Post/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, 
            [FromBody] PostDto dto,
            [FromServices] IModifyPostCommand command)
        {
          
                _executor.ExecuteCommandUpdate(command, dto, id);
                return NoContent();
          
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeletePostCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
