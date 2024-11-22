using App.core.Interface;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.Employee.Query
{
    public class GeyEmployeeByIdQuery : IRequest<Domain.Employee>
    {
        public int Id { get; set; }
    }

    public class GetEmployeeByIdQueryHandller : IRequestHandler<GeyEmployeeByIdQuery, Domain.Employee>
    {
        private readonly IAppDBContext applicationDbContext;

        public GetEmployeeByIdQueryHandller(IAppDBContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<Domain.Employee> Handle(GeyEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var model = request.Id;


            var deptid = await applicationDbContext.Set<Domain.Employee>().FindAsync(model);
            if (model == null)
            {
                return null;
            }

            return deptid;
        }
    }
}
