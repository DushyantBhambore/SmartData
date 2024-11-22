using App.Core.Apps.Command;
using App.Core.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Login2FA.Controllers
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

        [HttpPost("register")]
        public async Task<IActionResult> SignUp([FromBody] RegisterDto register)
        {
            var result = await _mediator.Send(new UserRegisterCommand { registerDto = register });
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            var result = await _mediator.Send(new UserLoginCommand { loginDto = login });
            return Ok(result);
        }

        [HttpPost("VerifyOtp")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpDto verifyOtpDto)
        {
            var result = await _mediator.Send(new VerifyOtpCommand { VerifyOtpDto = verifyOtpDto });
            return Ok(result);
        }
    }
}
