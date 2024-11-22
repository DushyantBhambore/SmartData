using App.Core.Interface;
using App.Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.Course.Command
{
    public class CreateDeparmentCommand : IRequest<int>
    {
        public DepartmentDto   Department { get; set; }
    }

    public class CreateDeparmentCommandHandller : IRequestHandler<CreateDeparmentCommand, int>
    {
        private readonly IApplicationDbContext applicationDbContext;

        public CreateDeparmentCommandHandller(IApplicationDbContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<int> Handle(CreateDeparmentCommand request, CancellationToken cancellationToken)
        {
            var model = request.Department;

            var dept = new Domain.Department
            {
                DepartmentId = model.DepartmentId,
                DepartmentName = model.DepartmentName,
            };

            await applicationDbContext.Set<Domain.Department>().AddAsync(dept);
            await  applicationDbContext.SaveChangesAsync(cancellationToken);

            return dept.DepartmentId;
        }
    }
}
