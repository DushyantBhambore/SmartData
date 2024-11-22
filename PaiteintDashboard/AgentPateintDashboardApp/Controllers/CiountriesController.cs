using App.Core.App.Country.Query;
using App.Core.App.States.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgentPateintDashboardApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiountriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CiountriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async  Task<IActionResult> GetAllCountries()
        {
            var message = _mediator.Send(new CountryQuery());
            return Ok(message);
        }
    }
}
