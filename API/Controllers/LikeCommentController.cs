using Application.DTO;
using Application.UseCases.Commands.LikeComments;
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
    public class LikeCommentController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public LikeCommentController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }
        // GET: api/<LikeCommentController>
        [HttpGet]
        public IActionResult Get([FromQuery] LikeCommentsSearch search, [FromServices] IGetLikeCommentQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query, search));
        }

        // GET api/<LikeCommentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LikeCommentController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] AddLikeCommentDto dto, [FromServices] IAddLikeCommentCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        // PUT api/<LikeCommentController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateLikeCommentDto dto, [FromServices] IUpdateLikeCommentCommand command)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<LikeCommentController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteLikeCommentCommand cmd)
        {
            BaseDTO dto = new BaseDTO();
            dto.Id = id;
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(204);
        }
    }
}
