﻿using App.Core.Apps.Command;
using App.Core.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticateController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Register")]
        public async Task<IActionResult>  Register(RegisterDto register)
        {
            var result = await _mediator.Send(new RegisterUserCommand { registerDto = register });
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = await _mediator.Send(new LoginCommand { loginDto = loginDto });
            return Ok(result);
        }
    }
}