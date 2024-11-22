using App.Core.Interface;
using App.Core.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.Department.Command
{
    public class UpdateDepartmentCommand : IRequest<string>
    {
        public int Id { get; set; }
        public DepartmentDto Department { get; set; }
    }

    public class UpdateDepartmentCommandHandller : IRequestHandler<UpdateDepartmentCommand, string>
    {
        private readonly IApplicationDbContext applicationDbContext;

        public UpdateDepartmentCommandHandller(IApplicationDbContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<string> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var model = request.Department;
            var deptid = request.Id;

            if(deptid !=model.DepartmentId)
            {
                return null;
            }
            var obj = applicationDbContext.Set<Domain.Department>().Find(deptid);
            if (obj != null)
            {
                obj.DepartmentName = model.DepartmentName;
               await applicationDbContext.SaveChangesAsync();
                return "Id Update Succecfully";
            }
            return null;
        }
    }
}
