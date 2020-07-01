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
    public class CategoryController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly IApplicationActor _actor;
        public CategoryController(UseCaseExecutor executor, IApplicationActor actor)
        {
            _executor = executor;
            _actor = actor;
        }
        // GET: api/Category
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Category/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id,[FromServices] IGetCategoryQuery query)
        {
            return Ok(_executor.ExecuteQuery(query,id));
        }

        // POST: api/Category
        [Authorize]
        [HttpPost]
        public void Post([FromBody] CategoryDto dto,
            [FromServices] ICreateCategoryCommand command)
        {
            _executor.ExecuteCommand(command, dto);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CategoryDto dto,
            [FromServices] IModifyCategoryCommand command)
        {
            try
            {
                _executor.ExecuteCommandUpdate(command, dto,id);
                    return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeleteCategoryCommand command)
        {
          
                _executor.ExecuteCommand(command, id);
                return NoContent();
           
        }
    }
}
