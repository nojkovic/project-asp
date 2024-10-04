using Application.DTO;
using Application.UseCases.Commands.Posts;
using Application.UseCases.Commands.Tags;
using Application.UseCases.Queries;
using Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public PostController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }
        // GET: api/<PostController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchPostDto search, [FromServices] IGetPostQuery query)
          => Ok(_useCaseHandler.HandleQuery(query, search));

        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetPostByIdQuery query)
          => Ok(_useCaseHandler.HandleQuery(query, id));


        // POST api/<PostController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] AddPostDto dto, [FromServices] IAddPostCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        // PUT api/<PostController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdatePostDto dto, [FromServices] IUpdatePostCommand command)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<PostController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeletePostCommand cmd)
        {
            BaseDTO dto = new BaseDTO();
            dto.Id = id;
            
            
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(204);
        }
    }
}
