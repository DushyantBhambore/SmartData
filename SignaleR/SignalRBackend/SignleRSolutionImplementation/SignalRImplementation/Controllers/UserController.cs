using App.Core.Apps.User.Command;
using App.Core.Apps.User.Query;
using App.Core.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRImplementation.Controllers
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
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDto user)
        {
            var result = await _mediator.Send(new UserLoginCommand { UserDto = user });
            return Ok(result);
        }
        [HttpPost("VerifyOtp")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOTPDto verifyOtpDto)
        {
            var result = await _mediator.Send(new VerifyotpQuery { VerifyOtpDto = verifyOtpDto });
            return Ok(result);
        }
    }
}
