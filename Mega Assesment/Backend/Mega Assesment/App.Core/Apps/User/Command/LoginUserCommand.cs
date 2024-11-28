using App.Core.Dtos;
using App.Core.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App.Core.Apps.User.Command
{
    public class LoginUserCommand : IRequest<object>
    {
        public LoginDto LoginDto { get; set; }
    }
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, object>
    {
        private readonly IAppDbContext _appDbContext;

        private readonly IEmailService _emailService;
        public LoginUserCommandHandler(IAppDbContext appDbContext, IEmailService emailService)
        {
            _appDbContext = appDbContext;
            _emailService = emailService;
        }

        public async Task<object> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {

            // Encrypt the provided username and password for comparison
            string encryptedUsername = Encrypt(request.LoginDto.Username);
            string encryptedPassword = Encrypt(request.LoginDto.Password);

            // Check for matching user
            var checkuser = await _appDbContext.Set<Domain.User>().Where(x => x.Username == encryptedUsername && x.Password == encryptedPassword).FirstOrDefaultAsync();

            if (checkuser == null)
            {
                return new { message = "Invalid username or password" };
            }

            // Generate OTP
            var otp = new Random().Next(100000, 999999).ToString();
            // Store OTP in database or cache with expiration time
            await _appDbContext.Set<Domain.Otp>().AddAsync(new Domain.Otp { Email = checkuser.Email, Code = otp, Expiration = DateTime.Now.AddMinutes(5) });
            await _appDbContext.SaveChangesAsync();

            // Send OTP to user's email
            await _emailService.SendEmailAsync(checkuser.Email, "Your OTP Code", $"Your OTP code is {otp}");

            return JsonSerializer.Serialize(new { message = "Otp send to your valid email" });

        }
        private string Encrypt(string input)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(data);
        }
    }
}
