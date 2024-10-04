using System.Reflection.Metadata;
using Application.DTO;
using Application.UseCases.Commands.Photos;
using Application.UseCases.Commands.Posts;
using Application.UseCases.Queries;
using Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public PhotoController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }
        // GET: api/<PhotoController>
        
        [HttpGet]
        public IActionResult Get([FromQuery] SearchPhoto search, [FromServices] IGetPhotoQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query, search));
        }

        // GET api/<PhotoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PhotoController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] AddPhotoDto dto,
                                  [FromServices] IAddPhotoCommand command)
        {
            _useCaseHandler.HandleCommand(command, dto);

            return StatusCode(201);
        }

        // PUT api/<PhotoController>/5
        [Authorize]
        [HttpPut("{id}")]

        public IActionResult Put(int id, [FromBody] UpdatePhotoDto dto, [FromServices] IUpdatePhotoCommand command)
        {
            dto.Id = id;
            _useCaseHandler.HandleCommand(command, dto);

            return NoContent();
        }

        // DELETE api/<PhotoController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeletePhotoCommand cmd)
        {
            PhotoDto dto = new PhotoDto();
            dto.Id = id;
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(204);
        }
    }
}
