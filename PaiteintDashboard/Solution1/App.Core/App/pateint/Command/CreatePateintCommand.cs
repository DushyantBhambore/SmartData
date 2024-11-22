using App.Core.Dto;
using App.Core.Interface;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Core.App.pateint.Command
{
    public class CreatePateintCommand : IRequest<int>
    {
        public PateintDto Pateint { get; set; }
    }

    public class CreatePateintCommnadHandler : IRequestHandler<CreatePateintCommand, int>
    {
        private readonly IAppDbContext _appDbContext;

        public CreatePateintCommnadHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> Handle(CreatePateintCommand request, CancellationToken cancellationToken)
        {

            var agent = await _appDbContext.Set<Domain.Agent>().Include(a => a.Patients)
                .FirstOrDefaultAsync(a => a.AgentId == request.Pateint.AgentId, cancellationToken);

            if (agent == null)
            {
                throw new Exception("Agent not found.");
            }
            var lastPatient = agent.Patients.OrderByDescending(p => p.PateintId).FirstOrDefault();
            string newPatientId;

            if (lastPatient == null)
            {
                newPatientId = $"{request.Pateint.AgentId}00001"; // First patient for this agent  
            }
            else
            {
                int numericPart = int.Parse(lastPatient.PateintId.Substring(request.Pateint.AgentId.Length));
                newPatientId = $"{request.Pateint.AgentId}{(numericPart + 1).ToString("D5")}"; // Increment patient number  
            }
            var pateint = new Domain.Pateint
            {
                PateintId = newPatientId,
                AId = request.Pateint.AId,
                FirstName = request.Pateint.FirstName,
                LastName = request.Pateint.LastName,
                DateOfBirth = request.Pateint.DateOfBirth,
                AgentId = request.Pateint.AgentId,
                Email = request.Pateint.Email,
                PhoneNumber = request.Pateint.PhoneNumber,
                Gender = request.Pateint.Gender,
                AddressLine1 = request.Pateint.AddressLine1,
                AddressLine2 = request.Pateint.AddressLine2,
                Countries = request.Pateint.Countries,
                States = request.Pateint.States,
                City = request.Pateint.City,
                BloodGroup = request.Pateint.BloodGroup,
                IsActive = request.Pateint.IsActive,
                IsDelete = request.Pateint.IsDelete
            };
            
            if (!pateint.IsDelete)
            {
                await _appDbContext.Set<Domain.Pateint>().AddAsync(pateint, cancellationToken);
            }

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return pateint.PId;

        }

    }
}

