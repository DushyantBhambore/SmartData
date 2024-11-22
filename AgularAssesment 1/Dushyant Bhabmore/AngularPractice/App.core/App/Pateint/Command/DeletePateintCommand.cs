using App.core.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.Pateint.Command
{
    public class DeletePateintCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
    public class DeletePateintCommandHandller : IRequestHandler<DeletePateintCommand, int>
    {
        private readonly IAppDBContext applicationDbContext;

        public DeletePateintCommandHandller(IAppDBContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<int> Handle(DeletePateintCommand request, CancellationToken cancellationToken)
        {
            var model = request.Id;

            var findid = applicationDbContext.Set<Domain.Pateints>().Find(model);

            if (findid != null)
            {
                applicationDbContext.Set<Domain.Pateints>().Remove(findid);
                await applicationDbContext.SaveChangesAsync();
                return findid.PateintId;
            }
            return 0;
        }
    }
}
