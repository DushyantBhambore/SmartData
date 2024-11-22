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
    public class ForgotPasswordCommand :IRequest<string>
    {
        public AgentForgotPasswordDto   Agent { get; set; }
    }

    public class ForgotPasswordCommnadHandler : IRequestHandler<ForgotPasswordCommand, string>
    {
        private readonly IAppDbContext _appDbContext;
        public ForgotPasswordCommnadHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<string> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var verify = _appDbContext.Set<Domain.Agent>().Any(x => x.Email == request.Agent.Email);
            if (!verify)
            {
                return Task.FromResult("Email Not Found");
            }
            var agent = _appDbContext.Set<Domain.Agent>().FirstOrDefault(x => x.Email == request.Agent.Email);
            agent.Password = BCrypt.Net.BCrypt.HashPassword(request.Agent.Password);
            request.Agent.ConfirmPssword = agent.Password;
            _appDbContext.SaveChangesAsync(cancellationToken);
            return Task.FromResult("Password Changed Successfully");
        
        }
    }
}
