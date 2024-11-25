using App.Core.Apps.Role.Command;
using App.Core.Apps.Role.Query;
using App.Core.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRImplementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole(RoleDto roleDto)
        {
            var result = await _mediator.Send(new AddRoleCommand { RoleDto = roleDto });
            return Ok(result);
        }

        [HttpPost("UpdateRole")]
        public async Task<IActionResult> UpdateRole(RoleDto roleDto)
        {
            var result = await _mediator.Send(new AddRoleCommand { RoleDto=roleDto });
            return Ok(result);
        }

        [HttpGet("GetAllRole")]
        public async Task<IActionResult> GetAllRole()
        {
            var result = await _mediator.Send(new GetAllRoleQuery());
            return Ok(result);

        }
        
    }
}
