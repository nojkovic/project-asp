using System.Runtime.Intrinsics.Arm;
using Application.DTO;
using Application.UseCases.Commands.PostTags;
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
    public class PostTagController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public PostTagController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }
        // GET: api/<PostTagController>
        [HttpGet]
        public IActionResult Get([FromQuery] PostTagSearch search, [FromServices] IGetPostTagQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query, search));
        }


        // POST api/<PostTagController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] AddPostTagDto dto, [FromServices] IAddPostTagCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        // PUT api/<PostTagController>/5
        

        // DELETE api/<PostTagController>/5
        [Authorize]
        [HttpDelete("{idT}/{idP}")]
        public IActionResult Delete(int idT, int idP, [FromServices] IDeletePostTagCommand cmd)
        {
            PostTagDto dto = new PostTagDto();
            dto.PostId = idP;
            dto.TagId = idT;
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(204);
        }
    }
}
