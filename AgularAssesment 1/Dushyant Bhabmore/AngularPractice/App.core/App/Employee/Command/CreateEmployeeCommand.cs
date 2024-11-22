using App.core.Interface;
using Domain;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.core.App.Employee.Command
{
    public class CreateEmployeeCommand : IRequest<int>
    {
        public Domain.Employee Emp { get; set; }
    }

    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
    {
        private readonly IAppDBContext _applicationDbContext;

        public CreateEmployeeCommandHandler(IAppDBContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var model = request.Emp;
           

            //var student = model.Adapt<Domain.Employee>();

            await _applicationDbContext.Set<Domain.Employee>().AddAsync(model);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return model.EmployeeID;
        }
    }

}
