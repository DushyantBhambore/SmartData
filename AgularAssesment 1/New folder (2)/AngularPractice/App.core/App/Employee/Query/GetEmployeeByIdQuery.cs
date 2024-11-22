using App.core.Dto;
using App.core.Interface;
using Domain;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.Employee.Query
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeDto>
    {
        public int Id { get; set; }
    }

    public class GetEmployeeByIdQueryHandller : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
    {
        private readonly IAppDBContext applicationDbContext;

        public GetEmployeeByIdQueryHandller(IAppDBContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var model = request.Id;


            var deptid = await applicationDbContext.Set<Domain.Employee>().FindAsync(model);
            if (model == null || deptid.IsDelete == true)
            {
                return null;
            }

            return deptid.Adapt<EmployeeDto>();
        }
    }
}
