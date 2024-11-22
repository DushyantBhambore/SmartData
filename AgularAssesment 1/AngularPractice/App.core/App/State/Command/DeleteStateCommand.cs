using App.core.Interface;
using MediatR;

namespace App.Core.Apps.Customer.Command

{
  public class DeleteStateCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
    public class DeleteStateCommandHandller : IRequestHandler<DeleteStateCommand, int>
    {
        private readonly IAppDBContext applicationDbContext;

        public DeleteStateCommandHandller(IAppDBContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<int> Handle(DeleteStateCommand request, CancellationToken cancellationToken)
        {
            var model = request.Id;

            var findid = applicationDbContext.Set<Domain.State>().Find(model);

            if (findid != null)
            {
                findid.IsDelete = true;
                findid.IsActive = false;
                await applicationDbContext.SaveChangesAsync();
                return findid.StateId;
            }
            return 0;
        }
    }
}
