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
    public class LoginAgentCommand : IRequest<string>
    {
        public AgentLoginDto Agent { get; set; }
    }

    public class LoginAgentCommandHandler : IRequestHandler<LoginAgentCommand, string>
    {
        private readonly IAppDbContext _appDbContext;
        public LoginAgentCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<string> Handle(LoginAgentCommand request, System.Threading.CancellationToken cancellationToken)
        {
            var agent =  _appDbContext.Set<Domain.Agent>().FirstOrDefault(x => x.Email == request.Agent.Email);
            var checkpassword = BCrypt.Net.BCrypt.Verify(request.Agent.Password, agent.Password);
            if (agent == null || checkpassword == 
                false)
            {
                return "Invalid Email or Password";
            }
            return "Login Successful";
        }
    }
}
