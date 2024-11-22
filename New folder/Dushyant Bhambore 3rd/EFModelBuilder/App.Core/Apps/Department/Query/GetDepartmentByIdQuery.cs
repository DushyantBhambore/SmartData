using App.Core.Interface;
using App.Core.Model;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.Department.Query
{
    public class GetDepartmentByIdQuery :IRequest<DepartmentDto>
    {
        public int Id{ get; set; }
    }

    public class GetDepartmentByIdHandller : IRequestHandler<GetDepartmentByIdQuery, DepartmentDto>
    {
        private readonly IApplicationDbContext applicationDbContext;

        public GetDepartmentByIdHandller(IApplicationDbContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<DepartmentDto> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var model = request.Id;
            
            
            var deptid =await applicationDbContext.Set<Domain.Department>().FindAsync(model);
            if (model == null)
            {
                return null;
            }

            return  deptid.Adapt<DepartmentDto>();
        }
    }

}
