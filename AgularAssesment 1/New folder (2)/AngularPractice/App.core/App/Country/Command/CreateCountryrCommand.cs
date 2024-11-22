using App.core.Dto;
using App.core.Interface;
using Domain;
using Mapster;
using MediatR;


namespace App.core.App.Country.Command
{
    public class CreateCountryrCommand : IRequest<int>
    {
        public CountryDto Country { get; set; }
    }

    public class CreateCountryrCommandHandler : IRequestHandler<CreateCountryrCommand, int>
    {
        private readonly IAppDBContext _applicationDbContext;

        public CreateCountryrCommandHandler(IAppDBContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<int> Handle(CreateCountryrCommand request, CancellationToken cancellationToken)
        {
            var model = request.Country;
           
            var customer = model.Adapt<Domain.Country>();
            await _applicationDbContext.Set<Domain.Country>().AddAsync(customer);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return model.CountryId;
        }
    }

}
