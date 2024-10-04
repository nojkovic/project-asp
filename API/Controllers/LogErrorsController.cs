using Application.UseCases.Queries;
using Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogErrorsController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;
        public LogErrorsController(UseCaseHandler useCaseHandler)
        {
            this._useCaseHandler = useCaseHandler;
        }

        // GET api/<LogErrorsController>/
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(string id, [FromServices] IGetLogErrorsQuery query)
           => Ok(_useCaseHandler.HandleQuery(query, id));
    }
}
