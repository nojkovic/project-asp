using Application.DTO;
using Application.UseCases.Commands.LikePosts;
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
    public class LikePostController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public LikePostController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }
        // GET: api/<LikePostController>
        [HttpGet]
        public IActionResult Get([FromQuery] LikePostSearch search, [FromServices] IGetLikePostQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query, search));
        }



        // POST api/<LikePostController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] AddLikePostDto dto, [FromServices] IAddLikePostCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        // PUT api/<LikePostController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateLikePostDto dto,
                                                  [FromServices] IUpdateLikePostCommand command)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<LikePostController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteLikePostCommand cmd)
        {
            BaseDTO dto=new BaseDTO();
            dto.Id = id;
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(204);
        }
    }
}
