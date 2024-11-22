using App.core.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.core.App.Pateint.Command
{
    public class UpdatePateintCommand : IRequest<string>
    {
        public Domain.Pateints Pateint { get; set; }
    }

    public class UpdatePateintCommandHandler : IRequestHandler<UpdatePateintCommand, string>
    {
        private readonly IAppDBContext applicationDbContext;

        public UpdatePateintCommandHandler(IAppDBContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }

        public async Task<string> Handle(UpdatePateintCommand request, CancellationToken cancellationToken)
        {
            var model = request.Pateint;
            var obj = await applicationDbContext.Set<Domain.Pateints>().FindAsync(model.PateintId);

            if (obj != null)
            {
                obj.FirstName = model.FirstName;
                obj.LastName = model.LastName;
                obj.Salary = model.Salary;
                obj.AddressLine1 = model.AddressLine1;
                obj.AddressLine2 = model.AddressLine2;
                obj.EmailAddress = model.EmailAddress;
                obj.PhoneNumber = model.PhoneNumber;
                obj.City = model.City;
                obj.State = model.State;
                obj.DateofBirth = model.DateofBirth;
                obj.PostalCode = model.PostalCode;
                obj.EmergencyContactName = model.EmergencyContactName;
                obj.EmergencyContactNumber = model.EmergencyContactNumber;
                obj.MaritalStatus = model.MaritalStatus;
                obj.IsActive = model.IsActive;
                obj.NextAppointmentDate = model.NextAppointmentDate;
                obj.LastVisitDate = model.LastVisitDate;
                obj.BloodPressure = model.BloodPressure;
                obj.BloodGroup = model.BloodGroup;
                obj.Weight = model.Weight;
                obj.Height = model.Height;
                obj.Allergies = model.Allergies;
                obj.PrimaryPhysician = model.PrimaryPhysician;
                obj.InsurancePolicyNumber = model.InsurancePolicyNumber;
                obj.InsuranceProvider = model.InsuranceProvider;

                await applicationDbContext.SaveChangesAsync();

                // Return a proper JSON response
                return "{\"message\":\"Id Updated Successfully\"}";
            }

            return "{\"message\":\"Patient not found\"}";

        }
    }
}
