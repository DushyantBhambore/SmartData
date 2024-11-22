using App.Core.Dto;
using App.Core.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace App.Core.App.Agent.Command
{
    public class RegisterAgentCommand : IRequest<string>
    {
        public AgentRegisterDto Agent { get; set; }
    }

    public class RegisterAgentCommandHandler : IRequestHandler<RegisterAgentCommand, string>
    {
        private readonly IAppDbContext _appDbContext;

        public RegisterAgentCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<string> Handle(RegisterAgentCommand request, CancellationToken cancellationToken)
        {
            var email =  _appDbContext.Set<Domain.Agent>().Any(x => x.Email == request.Agent.Email); // Check if email already exists in the table>
            if (email)
            {
                return "Email Already Exists";
            }

            var lastAgent = await _appDbContext.Set<Domain.Agent>().OrderByDescending(a => a.AgentId).FirstOrDefaultAsync(cancellationToken);
            string newAgentId;

            if (lastAgent == null)
            {
                // Initialize if the table is empty
                newAgentId = "PE001";
            }
            else
            {
                // Extract numeric part from last AgentId
                int numericPart = int.Parse(lastAgent.AgentId.Substring(2));
                // Increment and format with leading zeros
                newAgentId = $"PE{(numericPart + 1).ToString("D3")}";
            }
            // Hash the password
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Agent.Password);

            // Create and add the new agent
            var model = _appDbContext.Set<Domain.Agent>().Add(new Domain.Agent
            {
                AgentId = newAgentId,
                FirstName = request.Agent.FirstName,
                Email = request.Agent.Email,
                LastName = request.Agent.LastName, 
                Password = hashedPassword,
                ConfirmPassword =hashedPassword
            });
             await _appDbContext.SaveChangesAsync(cancellationToken);
            return "Agent Registered Successfully";
        }
    }
}
