using App.Core.Dtos;
using App.Core.Interface;
using MediatR;
using System.Text.Json;

namespace App.Core.Apps.Patient.Command
{
    public class UpdatePatientCommand : IRequest<string>
    {
        public PatientDto patientDto { get; set; }
    }
    public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, string>
    {
        private readonly IAppDbContext _context;

        public UpdatePatientCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var checkid = _context.Set<Domain.Patient>().Where(a => a.PId == request.patientDto.PId && a.IsACtive == true).FirstOrDefault();

            if (checkid == null)
            {
                return null;
            }
            checkid.PId = request.patientDto.PId;
            checkid.FirstName = request.patientDto.FirstName;
            checkid.LastName = request.patientDto.LastName;
            checkid.AgentId = request.patientDto.AgentId;
            checkid.UserId = request.patientDto.UserId;
            checkid.Email = request.patientDto.Email;
            checkid.PhoneNumber = request.patientDto.PhoneNumber;
            checkid.DateofBirth = request.patientDto.DateofBirth;
            checkid.AppoinentmentDate = request.patientDto.AppoinentmentDate;
            checkid.AddressLine1 = request.patientDto.AddressLine1;
            checkid.AddressLine2 = request.patientDto.AddressLine2;
            checkid.City = request.patientDto.City;
            checkid.Country = request.patientDto.Country;
            checkid.State = request.patientDto.State;
            checkid.Age = request.patientDto.Age;
            checkid.Gender = request.patientDto.Gender;
            checkid.ZipCode = request.patientDto.ZipCode;
            checkid.IsACtive = request.patientDto.IsACtive;
            checkid.IsDeleted = request.patientDto.IsDeleted;

            await _context.SaveChangesAsync(cancellationToken);
            return JsonSerializer.Serialize(new
            {
                message = "Id Updated Successfully"
            });
         
        }
    }
}
