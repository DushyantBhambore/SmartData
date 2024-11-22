using App.Core.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.Employee.Command
{
    public class DeleteEmployeeCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
    public class DeleteEmployeeCommandHandller : IRequestHandler<DeleteEmployeeCommand, int>
    {
        private readonly IApplicationDbContext applicationDbContext;

        public DeleteEmployeeCommandHandller(IApplicationDbContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<int> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var model = request.Id;

            var findid = applicationDbContext.Set<Domain.Employee>().FirstOrDefault(x => x.DepartmentId == model);

            if (findid != null)
            {
                applicationDbContext.Set<Domain.Employee>().Remove(findid);
                await applicationDbContext.SaveChangesAsync();
                return findid.DepartmentId;
            }
            return 0;
        }
    }
}
