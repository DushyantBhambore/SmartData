using App.Core.App.Agent.Command;
using App.Core.App.pateint.Command;
using App.Core.App.pateint.Query;
using App.Core.App.States.Query;
using App.Core.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgentPateintDashboardApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AgentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> AgentRegister(AgentRegisterDto registerDto)
        {
            var model = await _mediator.Send(new RegisterAgentCommand { Agent = registerDto });
            return Ok(model);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAgent(AgentLoginDto loginDto)
        {
            var model =await _mediator.Send(new LoginAgentCommand { Agent = loginDto });
            return Ok(model);
        }

        [HttpPost("forgotpassword")]
        public async Task<IActionResult> AgentRegister(AgentForgotPasswordDto forgotPasswordDto)
        {
            var model = await _mediator.Send(new ForgotPasswordCommand { Agent = forgotPasswordDto });
            return Ok(model);
        }

        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword(ChangePassword change)
        {
            var model =  await  _mediator.Send(new ChangePasswordCommand { password = change });
            return Ok(model);
        }


    }
}
