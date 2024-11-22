using App.Core.Interface;
using App.Core.Model;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.Department.Query
{
    public class GetDepartmentQuery : IRequest<List<DepartmentDto>>
    {
    }

    public class GetDepartmentQueryHandller : IRequestHandler<GetDepartmentQuery, List<DepartmentDto>>
    {
        private readonly IApplicationDbContext applicationDbContext;

        public GetDepartmentQueryHandller(IApplicationDbContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<List<DepartmentDto>> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
        {
            var deptlist = await applicationDbContext.Set<Domain.Department>().AsTracking().ToListAsync();

            return deptlist.Adapt<List<DepartmentDto>>();
        }
    }
}
