using App.Core.Dtos;
using App.Core.Interface;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.User.Command
{
    public class LoginUserCommand : IRequest<Domain.User>
    {
        public LoginDto loginDto { get; set; } 
    }
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Domain.User>
    {
        private readonly IAppDbContext _appDbContext;

        public LoginUserCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Domain.User> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {

            var checkemail = await _appDbContext.Set<Domain.User>().FirstOrDefaultAsync(x => x.Email == request.loginDto.Email );

            if (checkemail == null)
            {
                return null;
            }

            var verifypassword = BCrypt.Net.BCrypt.Verify(request.loginDto.Password,checkemail.Password);
            if(!verifypassword)
            {
                return null;
            }

            return checkemail;

        }
    }
}
