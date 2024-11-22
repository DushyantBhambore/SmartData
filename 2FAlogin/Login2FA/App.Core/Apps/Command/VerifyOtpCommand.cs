using App.Core.Dtos;
using App.Core.Interface;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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
    public class VerifyOtpCommand : IRequest<string>
    {
        public VerifyOtpDto VerifyOtpDto { get; set; }
    }
    public class VerifyOtpCommandHandller : IRequestHandler<VerifyOtpCommand, string>
    {
        private readonly IAppDbcontext _context;
        private readonly IConfiguration _configuration;

        public VerifyOtpCommandHandller(IAppDbcontext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<string> Handle(VerifyOtpCommand request, CancellationToken cancellationToken)
        {

            var verifyOtp = request.VerifyOtpDto;
            var otp = await _context.Set<Otp>().FirstOrDefaultAsync(x => x.Email == verifyOtp.Email && x.Code == verifyOtp.Otp);
        
            if (otp == null || otp.Expiration < DateTime.Now)
            {
                return "Invalid OTP";
            }
            var userExist = await _context.Set<Domain.User>().FirstOrDefaultAsync(x => x.Email == verifyOtp.Email);
            var claim = new[]
             {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim("UserId", userExist.UserId.ToString()),
                new Claim("Email", userExist.Email),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claim,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signIn);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return JsonSerializer.Serialize(new {message ="success", token = jwt });

           
        }
    }
}
