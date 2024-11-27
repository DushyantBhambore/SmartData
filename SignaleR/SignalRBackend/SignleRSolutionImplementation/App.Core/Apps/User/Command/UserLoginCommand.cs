using App.Core.Dto;
using App.Core.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App.Core.Apps.User.Command
{
    public class UserLoginCommand : IRequest<string>
    {
        public UserDto UserDto { get; set; }
    }
    public class UserLoginCommandHandller : IRequestHandler<UserLoginCommand, string>
    {
        private readonly IAppDbContext _appDbContext;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        public UserLoginCommandHandller(IAppDbContext appDbContext, IConfiguration configuration, IEmailService emailService)
        {
            _appDbContext = appDbContext;
            _configuration = configuration;
            _emailService = emailService;
        }

        public async Task<string> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var findemail = await _appDbContext.Set<Domain.User>().FirstOrDefaultAsync(a => a.Email == request.UserDto.Email && a.Password == request.UserDto.Password);

            if (findemail == null)
            {
                return JsonSerializer.Serialize(new { message = "Invalid Email and Password " });
            }
            // Generate OTP
            var otp = new Random().Next(100000, 999999).ToString();
            // Store OTP in database or cache with expiration time
            await _appDbContext.Set<Domain.OTP>().AddAsync(new Domain.OTP { Email = findemail.Email, Code = otp, Expiration = DateTime.Now.AddMinutes(5) });
            await _appDbContext.SaveChangesAsync();

            // Send OTP to user's email
            await _emailService.SendEmailAsync(findemail.Email, "Your OTP Code", $"Your OTP code is {otp}");

            return JsonSerializer.Serialize(new { message = "Otp send to your valid email" });

        }
    }
}
