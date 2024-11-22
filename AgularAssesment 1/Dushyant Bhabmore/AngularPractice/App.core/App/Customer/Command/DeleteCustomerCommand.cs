using App.core.Interface;
using MediatR;

namespace App.Core.Apps.Customer.Command

{
  public class DeleteCustomerCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
    public class DeleteCustomerCommandHandller : IRequestHandler<DeleteCustomerCommand, int>
    {
        private readonly IAppDBContext applicationDbContext;

        public DeleteCustomerCommandHandller(IAppDBContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<int> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var model = request.Id;

            var findid = applicationDbContext.Set<Domain.Customers>().Find(model);

            if (findid != null)
            {
                applicationDbContext.Set<Domain.Customers>().Remove(findid);
                await applicationDbContext.SaveChangesAsync();
                return findid.CustomerID;
            }
            return 0;
        }
    }
}
