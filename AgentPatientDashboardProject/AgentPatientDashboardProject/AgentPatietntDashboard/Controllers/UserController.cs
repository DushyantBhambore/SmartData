using App.Core.Apps.User.Command;
using App.Core.Dtos;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgentPatietntDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] RegisterDto userDto)
        {
            var result = await _mediator.Send(new RegisterUserCommand { register = userDto });
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var result = await _mediator.Send(new LoginUserCommand { loginDto = loginDto });
            return Ok(result);
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPassworddto forgotPassworddto)
        {
            var result = await _mediator.Send(new ForgotPasswordCommand { forgot = forgotPassworddto });
            return Ok(result);
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePassworddto changePasswordDto)
        {
            var result = await _mediator.Send(new ChangePasswodCommand { ChangePassworddto = changePasswordDto });
            return Ok(result);
        }

    }
}
