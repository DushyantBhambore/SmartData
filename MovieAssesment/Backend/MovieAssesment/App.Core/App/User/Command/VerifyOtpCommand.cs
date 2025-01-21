using App.Core.Interface;
using Doamin.ResponseModal;
using Doamin;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using App.Core.Dto;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace App.Core.App.User.Command
{
    public class VerifyOtpCommand  : IRequest<UserResponeModal>
    {
        public VerifyOtpDto VerifyOtp { get; set; }
    }
    public class verifyOtpCommandHandler : IRequestHandler<VerifyOtpCommand, UserResponeModal>
    {
        private readonly IAppDbContext _context;    
        private readonly IConfiguration _configuration;
        private readonly ILogger<verifyOtpCommandHandler> _logger;

        public verifyOtpCommandHandler(IAppDbContext context, ILogger<verifyOtpCommandHandler> logger,IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }
        public async Task<UserResponeModal> Handle(VerifyOtpCommand request, CancellationToken cancellationToken)
        {
            var verifyOtp = request.VerifyOtp;
            var otp = await _context.Set<Otp>().FirstOrDefaultAsync(x => x.Username == request.VerifyOtp.Username && x.Code == verifyOtp.Otp);

            if (otp == null || otp.Expiration < DateTime.Now)
            {
                _logger.LogError("Invalid OTP");
                return new UserResponeModal((int)HttpStatusCode.BadRequest, "Invalid OTP", null, null);
            }
            var userExist = await _context.Set<Doamin.User>().FirstOrDefaultAsync(x => x.UserName == request.VerifyOtp.Username);
            var selectrole = _context.Set<Doamin.Role>().FirstOrDefault(a => a.RoleId == userExist.RoleId);
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
            _logger.LogInformation("Login Successfully");
            return new UserResponeModal((int)HttpStatusCode.OK, "Login Successfully", userExist, jwt);
        }
    }
}
