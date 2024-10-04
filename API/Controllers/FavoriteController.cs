using Application.DTO;
using Application.UseCases.Commands.Favorites;
using Application.UseCases.Commands.PostTags;
using Application.UseCases.Queries;
using Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public FavoriteController(UseCaseHandler commandHandler)
        {
            _useCaseHandler = commandHandler;
        }
        // GET: api/<FavoriteController>
        [HttpGet]
        public IActionResult Get([FromQuery] FavoriteSearch search, [FromServices] IGetFavoriteQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query, search));
        }



        // POST api/<FavoriteController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] AddFavoriteDto dto, [FromServices] IAddFavoriteCommand cmd)
        {
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(201);
        }

        

        // DELETE api/<FavoriteController>/5
        [Authorize]
        [HttpDelete("{idU}/{idP}")]
        public IActionResult Delete(int idU, int idP, [FromServices] IDeleteFavoriteCommand cmd)
        {
            AddFavoriteDto dto = new AddFavoriteDto();
            dto.PostId = idP;
            dto.UserId = idU;
            _useCaseHandler.HandleCommand(cmd, dto);
            return StatusCode(204);
        }
    }
}
