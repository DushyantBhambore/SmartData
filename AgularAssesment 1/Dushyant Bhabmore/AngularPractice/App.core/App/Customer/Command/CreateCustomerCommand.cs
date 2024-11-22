using App.core.Interface;
using Domain;
using Mapster;
using MediatR;


namespace App.core.App.Customer.Command
{
    public class CreateCustomerCommand : IRequest<int>
    {
        public Domain.Customers Customer { get; set; }
    }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly IAppDBContext _applicationDbContext;

        public CreateCustomerCommandHandler(IAppDBContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var model = request.Customer;
           

            //var student = model.Adapt<Domain.Employee>();

            await _applicationDbContext.Set<Domain.Customers>().AddAsync(model);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return model.CustomerID;
        }
    }

}
