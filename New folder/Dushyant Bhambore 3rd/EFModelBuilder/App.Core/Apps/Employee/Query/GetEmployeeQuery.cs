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

namespace App.Core.Apps.Employee.Query
{
    public class GetEmployeeQuery : IRequest<List<EmployeeDto>>
    {

    }

    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, List<EmployeeDto>>
    {
        private readonly IApplicationDbContext appDbContext;
        public GetEmployeeQueryHandler(IApplicationDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }
        public async Task<List<EmployeeDto>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var list = await appDbContext.Set<Domain.Employee>()
                .AsNoTracking()
                .ToListAsync();

            return list.Adapt<List<EmployeeDto>>();
        }
    }

}
