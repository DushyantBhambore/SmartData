using App.Core.Apps.Command;
using App.Core.Apps.Query;
using App.Core.Dto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPut("UpdateUser")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> UpdateUser(UserDto userDto)
        {
            var result = await _mediator.Send(new UpdateUserCommand { UserDto = userDto });
            return Ok(result);
        }
        [HttpGet("GetAllUser")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUser()
        {
            var result = await _mediator.Send(new GetAllUserQuery());
            return Ok(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _mediator.Send(new DeleteUserCommand { Id = id });
            return Ok(result);
        }
    }
}
