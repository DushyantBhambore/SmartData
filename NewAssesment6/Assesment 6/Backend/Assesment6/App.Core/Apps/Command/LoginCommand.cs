using App.Core.Dto;
using App.Core.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace App.Core.Apps.Command
{
    public class LoginCommand : IRequest<string>
    {
        public LoginDto  loginDto { get; set; }
    }

    public class LoginCommandHandller : IRequestHandler<LoginCommand, string>
    {
        private readonly IAppDbContext _appDbContext;
        private readonly IConfiguration _configuration;
        public LoginCommandHandller(IAppDbContext appDbContext, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _configuration = configuration;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            // check the email and passsword 
            var checkemail = await _appDbContext.Set<Domain.User>()
                .FirstOrDefaultAsync(a => a.Email == request.loginDto.Email);

            var checkpassword = BCrypt.Net.BCrypt.Verify(request.loginDto.Password, checkemail.Password);

            if (checkemail == null && checkpassword ==null)
            {
                return JsonSerializer.Serialize(new { message = "Email and Password is not valid" });
            }
            // jwt token verification  and generation 
            var claim = new List<Claim>
           {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim("Id", checkemail.UserId.ToString()),
                new Claim("Email",checkemail.Email),
                new Claim("FirstName",checkemail.FirstName),
                //new Claim("Role",checkemail.Role)
            };
            var selectRole = await _appDbContext.Set<Domain.User>().Where(a => a.Role == request.loginDto.Role).Select(a => a.Role).ToListAsync();

            foreach (var r in selectRole)
            {
                claim.Add(new Claim(ClaimTypes.Role, r));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claim,
                expires: DateTime.UtcNow.AddMinutes(5),
                signingCredentials: signIn);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return JsonSerializer.Serialize(new { token = jwt, message = "Login SuccesFully", data =checkemail.Role , logindata=checkemail });
        }   
    }
}
