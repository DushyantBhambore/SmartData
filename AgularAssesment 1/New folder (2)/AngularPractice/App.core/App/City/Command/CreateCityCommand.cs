using App.core.Dto;
using App.core.Interface;
using Domain;
using Mapster;
using MediatR;


namespace App.core.App.City.Command
{
    public class CreateCityCommand : IRequest<int>
    {
        public CityDto City { get; set; }
    }

    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, int>
    {
        private readonly IAppDBContext _applicationDbContext;

        public CreateCityCommandHandler(IAppDBContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<int> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var model = request.City;
           
            var city = model.Adapt<Domain.City>();
            await _applicationDbContext.Set<Domain.City>().AddAsync(city);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return model.CityId;
        }
    }

}
