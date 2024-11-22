using App.core.Dto;
using App.core.Interface;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.City.Query
{
    public class GetCityByIdQuery : IRequest<CityDto>
    {
        public int Id { get; set; }
    }

    public class GetCityByIdQueryHandller : IRequestHandler<GetCityByIdQuery, CityDto>
    {
        private readonly IAppDBContext applicationDbContext;

        public GetCityByIdQueryHandller(IAppDBContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<CityDto> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        {
            var model = request.Id;
            var customerid = await applicationDbContext.Set<Domain.City>().FindAsync(model);
            if (model == null || customerid.IsDelete== true)
            {
                return null;
            }
            return customerid.Adapt<CityDto>();
        }
    }
}
