using App.Core.Dto;
using App.Core.Interface;
using Doamin.ResponseModal;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace App.Core.App.User.Command
{
    public class LoginUserCommand : IRequest<JsonModal>
    {
        public loginDto LoginDto { get; set; }
    }
    public class LoginUserCommandHandller : IRequestHandler<LoginUserCommand, JsonModal>
    {
        private readonly IAppDbContext _appDbContext;
        private readonly IEmailService _emailService;
        private readonly ILogger<LoginUserCommandHandller> _logger;
        public LoginUserCommandHandller(IAppDbContext appDbContext, ILogger<LoginUserCommandHandller> logger,IEmailService emailService)
        {
            _appDbContext = appDbContext;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<JsonModal> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var checkuser = await _appDbContext.Set<Doamin.User>().Where(x => x.UserName == request.LoginDto.UserName).FirstOrDefaultAsync();
            if (checkuser == null)
            {
                _logger.LogError("Username  and Password is  Invalid");
                return new JsonModal((int)HttpStatusCode.BadRequest, "Username  and Password is  Invalid", null);
            }
            var checkpassword = BCrypt.Net.BCrypt.Verify(request.LoginDto.Password, checkuser.Password);
            if (!checkpassword)
            {
                _logger.LogError("Username  and Password is  Invalid");
                return new JsonModal((int)HttpStatusCode.BadRequest, "Username  and Password is  Invalid", null);
            }
            // Generate OTP
            var otp = new Random().Next(100000, 999999).ToString();

            var existingOtps = await _appDbContext.Set<Doamin.Otp>()
            .Where(o => o.Username.ToLower() == checkuser.UserName.ToLower())
            .ToListAsync(cancellationToken);
            if (existingOtps.Any())
            {
                _appDbContext.Set<Doamin.Otp>().RemoveRange(existingOtps);
            }

            await _appDbContext.Set<Doamin.Otp>().AddAsync(new Doamin.Otp { Email = checkuser.Email, Username = checkuser.UserName, Code = otp, Expiration = DateTime.Now.AddMinutes(5) });
            await _appDbContext.SaveChangesAsync();
            await _emailService.SendEmailAsync(checkuser.Email, "Your OTP Code", $"Your OTP code is {otp}");
            _logger.LogInformation("Otp is Send Successfully");
            return new JsonModal((int)HttpStatusCode.OK, "Otp is Send Successfully", checkuser);
        }
    }
}
