using App.core.Dto;
using App.core.Interface;
using Domain;
using Mapster;
using MediatR;


namespace App.core.App.Customer.Command
{
    public class CreateCityCommand : IRequest<int>
    {
        public CustomerDto Customer { get; set; }
    }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCityCommand, int>
    {
        private readonly IAppDBContext _applicationDbContext;

        public CreateCustomerCommandHandler(IAppDBContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<int> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var model = request.Customer;
           
            var customer = model.Adapt<Domain.Customers>();
            await _applicationDbContext.Set<Domain.Customers>().AddAsync(customer);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return model.CustomerID;
        }
    }

}
