using App.Core.App.Role.Command;
using App.Core.App.Role.Query;
using App.Core.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
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
        [HttpPost]
       public async Task<IActionResult> AddRole([FromBody] RoleDto roleDto)
        {
            var result = await _mediator.Send(new AddRoleCommand { RoleDto = roleDto });
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRole()
        {
            var result = await _mediator.Send(new GetAllRoleQuery());
            return Ok(result);
        }
    }
}
