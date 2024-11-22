using App.core.Interface;
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
        private readonly IAppDBContext applicationDbContext;

        public DeleteEmployeeCommandHandller(IAppDBContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<int> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var model = request.Id;

            var findid = applicationDbContext.Set<Domain.Employee>().Find(model);

            if (findid != null)
            {
                findid.IsDelete = true;
                findid.IsActive = false;
                //applicationDbContext.Set<Domain.Employee>().Remove(findid);
                await applicationDbContext.SaveChangesAsync();
                return findid.EmployeeID;
            }
            return 0;
        }
    }
}
