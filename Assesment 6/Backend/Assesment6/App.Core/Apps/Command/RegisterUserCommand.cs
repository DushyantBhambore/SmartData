using App.Core.Dto;
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
    public class RegisterUserCommand : IRequest<string>
    {
        public RegisterDto registerDto { get; set; }
    }
    public class RegisterCommandHandller : IRequestHandler<RegisterUserCommand, string>
    {
        private readonly IAppDbContext _appDbContext;

        public RegisterCommandHandller(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var checkemail = await _appDbContext.Set<Domain.User>().FirstOrDefaultAsync(a => a.UserId == request.registerDto.UserId);
              
            if(checkemail != null)
            {
                return JsonSerializer.Serialize(new { message = "Email is Already Exits" });
            }
            var hashpassword =BCrypt.Net.BCrypt.HashPassword(request.registerDto.Password);
            var newuser = new Domain.User
            {
                UserId = request.registerDto.UserId,
                UserName = request.registerDto.UserName,
                Email = request.registerDto.Email,
                FirstName = request.registerDto.FirstName,
                LastName = request.registerDto.LastName,
                Country = request.registerDto.Country,
                State = request.registerDto.State,
                City = request.registerDto.City,
                Role = request.registerDto.Role,
                Password = hashpassword,
                IsActive = request.registerDto.IsActive,
                IsDelete = request.registerDto.IsDelete,
            };
            await _appDbContext.Set<Domain.User>().AddAsync(newuser);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return JsonSerializer.Serialize(new { message = "Register SuccessFully " , data = newuser});
        }
    }
}
