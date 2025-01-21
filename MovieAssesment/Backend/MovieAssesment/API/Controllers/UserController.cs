using App.Core.App.User.Command;
using App.Core.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
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
        public async Task<IActionResult> AddUser([FromBody]  registerDto registerDto)
        {
            var result = await _mediator.Send(new RegisterUserCommand { registerDto = registerDto });
            return Ok(result);
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] registerDto updateDto)
        {
            var result = await _mediator.Send(new UpdateUserCommand { RegisterDto = updateDto });
            return Ok(result);
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
            var result = await _mediator.Send(new ChangePasswordCommand { ChangePasswordDto = changePasswordDto });
            return Ok(result);
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPasswordDto)
        {
            var result = await _mediator.Send(new ForgetPasswordCommand { forgotEamilDto = forgotPasswordDto });
            return Ok(result);
        }

        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUser([FromBody] loginDto loginDto)
        {
            var result = await _mediator.Send(new  LoginUserCommand { LoginDto = loginDto });
            return Ok(result);
        }

        [HttpPost("VerifyOTP")]
        public async Task<IActionResult> VerifyOTP([FromBody] VerifyOtpDto verifyOtpDto)
        {
            var result = await _mediator.Send(new VerifyOtpCommand { VerifyOtp = verifyOtpDto });
            return Ok(result);
        }


    }
}
