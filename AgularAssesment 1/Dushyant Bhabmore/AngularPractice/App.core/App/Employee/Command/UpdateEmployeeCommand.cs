using App.core.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.core.App.Employee.Command
{
    public class UpdateEmployeeCommand : IRequest<string>
    {
        public Domain.Employee Employee { get; set; }
    }
    public class UpdateEmployeeCommandHandller : IRequestHandler<UpdateEmployeeCommand, string>
    {
        private readonly IAppDBContext applicationDbContext;

        public UpdateEmployeeCommandHandller(IAppDBContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<string> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var model = request.Employee;

            var obj = applicationDbContext.Set<Domain.Employee>().Find(model.EmployeeID);
            if (obj != null)
            {
                obj.FirstName = model.FirstName;
                obj.LastName = model.LastName;
                obj.Salary = model.Salary;
                obj.Address = model.Address;
                obj.EmailAddress = model.EmailAddress;
                obj.PhoneNumber = model.PhoneNumber;
                obj.City = model.City;
                obj.State = model.State;
                obj.DateofBirth = model.DateofBirth;
                obj.Department = model.Department;
                obj.Salary = model.Salary;
                obj.EmergencyContactName = model.EmergencyContactName;
                obj.EmergencyContactNumber = model.EmergencyContactNumber;
                obj.MaritalStatus = model.MaritalStatus;
                obj.EducationLevel = model.EducationLevel;
                obj.Country = model.Country;
                obj.IsExpericed = model.IsExpericed;
                obj.Skills = model.Skills;
                obj.PositionTitle = model.PositionTitle;
                obj.DateofHire = model.DateofHire;
                await applicationDbContext.SaveChangesAsync();
                return "{\"message\":\"Id Updated Successfully\"}";
            }
            return "{\"message\":\"Patient not found\"}";
        }
    }
}