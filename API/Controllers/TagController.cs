using Application.DTO;
using Application.UseCases.Commands.Tags;
using Application.UseCases.Commands.Users;
using Application.UseCases.Queries;
using Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public TagController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }
        // GET: api/<TagController>
        [HttpGet]
        public IActionResult Get([FromQuery] TagSearch search, [FromServices] IGetTagQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query, search));
        }

        // GET api/<TagController>/5


        // POST api/<TagController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] AddTagDto dto, [FromServices] IAddTagCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        // PUT api/<TagController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateTagDto dto,[FromServices] IUpdateTagCommand command)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<TagController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteTagCommand cmd)
        {
            BaseDTO dto = new BaseDTO();
            dto.Id = id;
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(204);
        }
    }
}
