using App.Core.Dto;
using App.Core.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.App.Agent.Command
{
    public class ChangePasswordCommand :IRequest<string>
    {
        public ChangePassword password { get; set; }
    }

    public  class ChangePasswordCommnadHandler : IRequestHandler<ChangePasswordCommand, string>
    {
        private readonly IAppDbContext _appDbContext;

        public ChangePasswordCommnadHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<string> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var agent = _appDbContext.Set<Domain.Agent>().FirstOrDefault(x => x.Email == request.password.Email);
            if (agent == null)
            {
                return "Invalid Email";
            }
            var checkpassword = BCrypt.Net.BCrypt.Verify(request.password.OldPassword, agent.Password);
            if (!checkpassword)
            {
                return "Invalid Old Password";
            }

            agent.Password = BCrypt.Net.BCrypt.HashPassword(request.password.NewPassword);
            agent.ConfirmPassword = agent.Password;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return "Password Changed Successfully";

        }
    }
}
