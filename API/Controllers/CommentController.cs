using System.Reflection.Metadata;
using Application.DTO;
using Application.UseCases.Commands.Comments;
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
    public class CommentController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public CommentController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }
        // GET: api/<CommentController>
        [HttpGet]
        public IActionResult Get([FromQuery] SearchCommentsDTO search, [FromServices] IGetCommentQuery query)
          => Ok(_useCaseHandler.HandleQuery(query, search));

        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetCommentByIdQuery query)
           => Ok(_useCaseHandler.HandleQuery(query, id));

        // POST api/<CommentController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromServices] IAddCommentCommand command,
                                  [FromBody] AddCommentDto dto)
        {
            try
            {
                _useCaseHandler.HandleCommand(command, dto);
                return StatusCode(201);
            }
            
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // PUT api/<CommentController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCommentDto dto, [FromServices] IUpdateCommentComand command)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<CommentController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCommentCommand cmd)
        {
            BaseDTO dto = new BaseDTO();
            dto.Id = id;
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(204);
        }
    }
}
