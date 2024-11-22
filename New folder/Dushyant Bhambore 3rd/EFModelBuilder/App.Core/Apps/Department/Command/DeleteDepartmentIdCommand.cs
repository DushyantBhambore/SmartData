using App.Core.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.Department.Command
{
    public class DeleteDepartmentIdCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

    public class DeleteDepartmentIdCommandHandller : IRequestHandler<DeleteDepartmentIdCommand, int>
    {
        private readonly IApplicationDbContext applicationDbContext;

        public DeleteDepartmentIdCommandHandller(IApplicationDbContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<int> Handle(DeleteDepartmentIdCommand request, CancellationToken cancellationToken)
        {
            var model = request.Id;

            var findid = applicationDbContext.Set<Domain.Department>().FirstOrDefault(x => x.DepartmentId == model);

            if (findid != null)
            {
                applicationDbContext.Set<Domain.Department>().Remove(findid);
               await applicationDbContext.SaveChangesAsync();
                return findid.DepartmentId;
            }
            return 0;
        }
    }
}
