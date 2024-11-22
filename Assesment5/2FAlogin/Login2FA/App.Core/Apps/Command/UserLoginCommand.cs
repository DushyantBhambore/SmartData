using App.Core.Dtos;
using App.Core.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App.Core.Apps.Command
{
    public class UserLoginCommand : IRequest<string>
    {
        public LoginDto loginDto { get; set; }
    }
    public class UserLoginCommandHandller : IRequestHandler<UserLoginCommand, string>
    {
        private readonly IAppDbcontext _appDbcontext;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;


        public UserLoginCommandHandller(IAppDbcontext appDbcontext, IConfiguration configuration , IEmailService emailService)
        {
            _appDbcontext = appDbcontext;
            _configuration = configuration;
            _emailService = emailService;


        }
        public async Task<string> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var checkemail = await _appDbcontext.Set<Domain.User>().FirstOrDefaultAsync(x => x.Email == request.loginDto.Email);
            if (checkemail == null)
            {
                return JsonSerializer.Serialize(new { message = "Email is not Found" });
            }
            var checkpassword = BCrypt.Net.BCrypt.Verify(request.loginDto.Password, checkemail.Password);
            if (!checkpassword)
            {
                return JsonSerializer.Serialize(new { message = "Email is not Found" });
            }

            // Generate OTP
            var otp = new Random().Next(100000, 999999).ToString();
            // Store OTP in database or cache with expiration time
            await _appDbcontext.Set<Domain.Otp>().AddAsync(new Domain.Otp { Email = checkemail.Email, Code = otp, Expiration = DateTime.Now.AddMinutes(5) });
            await _appDbcontext.SaveChangesAsync();

            // Send OTP to user's email
            await _emailService.SendEmailAsync(checkemail.Email, "Your OTP Code", $"Your OTP code is {otp}");

            return JsonSerializer.Serialize(new { message = "Otp send to your valid email"});
           

        }
    }
}
