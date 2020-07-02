using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekat.Application;
using Projekat.Application.Commands;
using Projekat.Application.DataTransfer;

namespace Projekat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public RateController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // POST: api/Rate
        [HttpPost]
        public IActionResult Post(int id,[FromBody] RateDto dto,[FromServices] IRatePostCommand command)
        {
            _executor.ExecuteCommandRate(command, dto, id);
            return NoContent();
        }

    }
}
