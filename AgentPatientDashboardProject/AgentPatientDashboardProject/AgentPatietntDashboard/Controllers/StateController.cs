using App.Core.Apps.State.Command;
using App.Core.Apps.State.Query;
using App.Core.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AgentPatietntDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddState")]
        public async Task<IActionResult> AddState([FromBody] StateDto stateDto)
        {
            var result = await _mediator.Send(new AddStateCommand { stateDto = stateDto });
            return Ok(result);
        }

        [HttpGet("GetAllState")]
        public async Task<IActionResult> GetAllState()
        {
            var result = await _mediator.Send(new GeAllStateQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStateById(int id)
        {
            var result = await _mediator.Send(new GetStateByIdQuery { id = id });
            return Ok(result);
        }

    }
}
