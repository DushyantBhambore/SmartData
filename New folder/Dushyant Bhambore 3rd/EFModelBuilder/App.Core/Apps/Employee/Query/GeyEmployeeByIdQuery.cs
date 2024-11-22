using App.Core.Interface;
using App.Core.Model;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.Employee.Query
{
    public class GeyEmployeeByIdQuery : IRequest<EmployeeDto>
    {
        public int Id { get; set; }
    }

    public class GetEmployeeByIdQueryHandller : IRequestHandler<GeyEmployeeByIdQuery, EmployeeDto>
    {
        private readonly IApplicationDbContext applicationDbContext;

        public GetEmployeeByIdQueryHandller(IApplicationDbContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<EmployeeDto> Handle(GeyEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var model = request.Id;


            var deptid = await applicationDbContext.Set<Domain.Employee>().FindAsync(model);
            if (model == null)
            {
                return null;
            }

            return deptid.Adapt<EmployeeDto>();
        }
    }
}
