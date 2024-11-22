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

namespace App.Core.Apps.Patient.Command
{
    public class AddPatientCommand : IRequest<PatientDto>
    {
        public PatientDto patientDto { get; set; }
    }
    public class AddPatientCommandHandler : IRequestHandler<AddPatientCommand, PatientDto>
    {
        private readonly IAppDbContext _context;

        public AddPatientCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<PatientDto> Handle(AddPatientCommand request, CancellationToken cancellationToken)
        {
            var findagentid = await _context.Set<Domain.User>().Include(a => a.Patients).FirstOrDefaultAsync(x => x.AgentId == request.patientDto.AgentId, cancellationToken);
            if (findagentid == null)
            {
                return null;
            }
            var lastpatientid = await _context.Set<Domain.Patient>().Where(x => x.AgentId == request.patientDto.AgentId).OrderByDescending(x => x.PatientId).FirstOrDefaultAsync(cancellationToken);
            string newpatientid;

            // If no patients exist, start from 1.
            if (lastpatientid == null)
            {
                newpatientid = $"{request.patientDto.AgentId}00001";
            }
            else
            {
                var value = int.Parse(lastpatientid.PatientId.Substring(request.patientDto.AgentId.Length));
                newpatientid = $"{lastpatientid.AgentId}{(value + 1).ToString("D5")}";
            }

            var newpatient = new Domain.Patient
            {
                PId = request.patientDto.PId,
                PatientId = newpatientid,
                FirstName = request.patientDto.FirstName,
                LastName = request.patientDto.LastName,
                AgentId = request.patientDto.AgentId,
                UserId = request.patientDto.UserId,
                Email = request.patientDto.Email,
                PhoneNumber = request.patientDto.PhoneNumber,
                DateofBirth = request.patientDto.DateofBirth,
                AppoinentmentDate = request.patientDto.AppoinentmentDate,
                AddressLine1 = request.patientDto.AddressLine1,
                AddressLine2 = request.patientDto.AddressLine2,
                City = request.patientDto.City,
                Country = request.patientDto.Country,
                State = request.patientDto.State,
                Age = request.patientDto.Age,
                Gender = request.patientDto.Gender,
                ZipCode = request.patientDto.ZipCode,
                IsACtive = request.patientDto.IsACtive,
                IsDeleted = request.patientDto.IsDeleted,


            };

            await _context.Set<Domain.Patient>().AddAsync(newpatient, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return newpatient.Adapt<PatientDto>();
        }
    }
}
