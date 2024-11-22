using App.Core.Dtos;
using App.Core.Interface;
using Domain;
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
    public class ForgotPasswordCommand : IRequest<string>
    {
        public ForgotPassworddto forgot { get; set; }
    }
    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, string>
    {
        private readonly IAppDbContext _appDbContext;

        public ForgotPasswordCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<string> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {

            var checkemail = await _appDbContext.Set<Domain.User>().FirstOrDefaultAsync(x => x.Email == request.forgot.Email);

            if(checkemail == null)
            {
                return JsonSerializer.Serialize("Email not found");
            }
          
            var updatepassword = BCrypt.Net.BCrypt.HashPassword(request.forgot.NewPassword);


            checkemail.Password = updatepassword;
            checkemail.ConfirmPassword = updatepassword;

            await _appDbContext.SaveChangesAsync(); 

            return JsonSerializer.Serialize(new
            {
                message = "Password updated successfully",
            });
        }
    }
}
