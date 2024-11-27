using App.Core.Dto;
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

namespace App.Core.Apps.User.Query
{
    public class VerifyotpQuery : IRequest<string>
    {
        public VerifyOTPDto VerifyOtpDto { get; set; }
    }

    public class VerifyitoQueryHandller : IRequestHandler<VerifyotpQuery, string>
    {

        private readonly IAppDbContext _context;
        private readonly IConfiguration _configuration;

        public VerifyitoQueryHandller(IAppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<string> Handle(VerifyotpQuery request, CancellationToken cancellationToken)
        {

            var verifyOtp = request.VerifyOtpDto;
            var otp = await _context.Set<OTP>().FirstOrDefaultAsync(x => x.Email == verifyOtp.Email && x.Code == verifyOtp.Otp);

            if (otp == null || otp.Expiration < DateTime.Now)
            {
                return "Invalid OTP";
            }
            var userExist = await _context.Set<Domain.User>().FirstOrDefaultAsync(x => x.Email == verifyOtp.Email);
            var selectrole =  _context.Set<Domain.Roles>().FirstOrDefault(a => a.RoleId == userExist.RoleId);
            var claim = new[]
             {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim("UserId", userExist.UserId.ToString()),
                new Claim("Email", userExist.Email),
                new Claim(ClaimTypes.Role,selectrole.RoleName)
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
            return JsonSerializer.Serialize(new { message = "success", token = jwt });

        }
    }
}
