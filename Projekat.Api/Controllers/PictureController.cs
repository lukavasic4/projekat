using System;
using System.Collections.Generic;
using System.IO;
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
    public class PictureController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public PictureController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/Picture
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Picture/5
        [HttpGet("{id}", Name = "Get2")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Picture
        [HttpPost]
        public void Post([FromForm] PictureDto dto,
            [FromServices] ICreatePictureCommand command)
        {
            _executor.ExecuteCommand(command, dto);
        }

        // PUT: api/Picture/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
   
}
