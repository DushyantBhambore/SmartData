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

namespace App.Core.Apps.Command
{
    public class UserRegisterCommand : IRequest<string>
    {
        public RegisterDto  registerDto { get; set; }
    }
    public class UserRegisterCommandHandller : IRequestHandler<UserRegisterCommand, string>
    {
        private readonly IAppDbcontext _appDbcontext;

        public UserRegisterCommandHandller(IAppDbcontext appDbcontext)
        {
            _appDbcontext = appDbcontext;
        }
        public async Task<string> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            var checkemail = await _appDbcontext.Set<Domain.User>().FirstOrDefaultAsync(x => x.Email == request.registerDto.Email);

            if ((checkemail != null))
            {
                return JsonSerializer.Serialize(new { message = "Email is NOt Found " });
            }
            var hashpassword = BCrypt.Net.BCrypt.HashPassword(request.registerDto.Password);

            var user = new Domain.User
            {
                UserId = request.registerDto.UserId,
                Email = request.registerDto.Email,
                Username = request.registerDto.Username,
                Password = hashpassword,
                ConfirmPassword = hashpassword,
            };
            await _appDbcontext.Set<Domain.User>().AddAsync(user);
            await _appDbcontext.SaveChangesAsync(cancellationToken);

            return JsonSerializer.Serialize(new { message = "User Regiter Successfuloly " });
        }
    }
}
