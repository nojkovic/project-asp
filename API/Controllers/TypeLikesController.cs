using Application.DTO;
using Application.UseCases.Commands.TypeLikes;
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
    public class TypeLikesController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public TypeLikesController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }
        // GET: api/<TypeLikesController>
        [HttpGet]
        public IActionResult Get([FromQuery] TypeLikeSearch search, [FromServices] IGetTypeLikeQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query, search));
        }



        // POST api/<TypeLikesController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] AddTypeLikeDto dto, [FromServices] IAddTypeLikeCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        // PUT api/<TypeLikesController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateTypeLikeDto dto,
         [FromServices]IUpdateTypeLikeCommand command)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<TypeLikesController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteTypeLikeCommand cmd)
        {
            BaseDTO dto = new BaseDTO();
            dto.Id = id;
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(204);
        }
    }
}
