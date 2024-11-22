using App.Core.Interface;
using App.Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.Employee.Command
{
    public class UpdateEmployeeCommand : IRequest<string>
    {
        public int Id { get; set; }
        public EmployeeDto Employee { get; set; }
    }

    public class UpdateEmployeeCommandHandller : IRequestHandler<UpdateEmployeeCommand, string>
    {
        private readonly IApplicationDbContext applicationDbContext;

        public UpdateEmployeeCommandHandller(IApplicationDbContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<string> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var model = request.Employee;
            var empid = request.Id;

            if (empid != model.EmployeeID)
            {
                return null;
            }
            var obj = applicationDbContext.Set<Domain.Employee>().Find(empid);
            if (obj != null)
            {
                obj.FirstName = model.FirstName;
                obj.LastName = model.LastName;
                obj.Salary = model.Salary;
                obj.DepartmentId = model.DepartmentId;
                await applicationDbContext.SaveChangesAsync();
                return "Id Update Succecfully";
            }
            return null;
        }
    }
}
