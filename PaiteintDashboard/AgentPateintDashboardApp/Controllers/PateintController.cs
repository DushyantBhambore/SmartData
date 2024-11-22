using App.Core.App.pateint.Command;
using App.Core.App.pateint.Query;
using App.Core.Dto;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgentPateintDashboardApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PateintController : ControllerBase
    {
        private readonly IMediator _mediator; 
        public PateintController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreatePateint(PateintDto pateintDto)
        {
            var pateint =await _mediator.Send(new CreatePateintCommand { Pateint = pateintDto });
            return Ok(pateint);
        }

        [HttpGet("action{id}")]
        public async Task<IActionResult> GetPateintById(int id)
        {
            var pateintbyid = await _mediator.Send(new GetPateintByIdQuery { Id = id });
            return Ok(pateintbyid);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPateint()
        {
            var message =await _mediator.Send(new GetAllPateintQuery());
            return Ok(message);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePateint(PateintDto pateintDto)
        {
            var updatepateint = await _mediator.Send(new PateintUpdateCommand { Pateint = pateintDto });
            return Ok(updatepateint);
        }

        [HttpDelete("action{id}")]
        public async Task<IActionResult> DeletePateint(int id)
        {
            var deletepateint =await _mediator.Send(new PateintDeleteCommand { PateintId = id });
            return Ok(deletepateint);
        }
    }
}
