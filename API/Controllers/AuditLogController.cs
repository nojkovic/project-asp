using Application.DTO;
using Application.UseCases.Queries;
using Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditLogController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;
        public AuditLogController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }


        // GET: api/<AuditLogController>
        [Authorize]
        [HttpGet]
        public IActionResult Get([FromQuery] AuditLogSearchDto search, [FromServices] IGetAuditLogQuery query)
            => Ok(_useCaseHandler.HandleQuery(query, search));
    }
}
