using App.Core.Dtos;
using App.Core.Interface;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace App.Core.Apps.User.Command
{
    public class VerifyOtpCommand : IRequest<object>
    {
        public VerifyOtpDto VerifyOtp { get; set; }
    }
    public class verifyOtpCommandHandler : IRequestHandler<VerifyOtpCommand, object>
    {
        private readonly IAppDbContext _context;
        private readonly IConfiguration _configuration;

        public verifyOtpCommandHandler(IAppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<object> Handle(VerifyOtpCommand request, CancellationToken cancellationToken)
        {

            string encryptedUsername = Encrypt(request.VerifyOtp.Username);

            var verifyOtp = request.VerifyOtp;
            var otp = await _context.Set<Otp>().FirstOrDefaultAsync(x => x.Username== encryptedUsername && x.Code == verifyOtp.Otp);

            if (otp == null || otp.Expiration < DateTime.Now)
            {
                return "Invalid OTP";
            }
            var userExist = await _context.Set<Domain.User>().FirstOrDefaultAsync(x => x.Username == encryptedUsername);
            var selectrole = _context.Set<Domain.Role>().FirstOrDefault(a => a.RoleId == userExist.RoleId);
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
        private string Encrypt(string input)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(data);
        }
    }
}
