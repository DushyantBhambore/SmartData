using App.Core.Apps.Agent.Command;
using App.Core.Apps.Agent.Query;
using App.Core.Apps.Patient.Command;
using App.Core.Dto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRImplementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AgentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AgentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddorUpdate(AgentDto agentDto)
        {
            var result = await _mediator.Send(new AgentCommad { AgentDto = agentDto });
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAgent()
        {
            var result = await _mediator.Send(new GetAllAgentQuery());
            return Ok(result);
        }
    }
}
