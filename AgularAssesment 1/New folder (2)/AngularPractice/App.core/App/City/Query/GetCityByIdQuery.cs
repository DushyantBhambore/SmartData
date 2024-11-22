using App.core.Dto;
using App.core.Interface;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.City.Query
{
    public class GetCityByIdQuery : IRequest<List<CityDto>>
    {
        public int Id { get; set; }
    }

    public class GetCityByIdQueryHandller : IRequestHandler<GetCityByIdQuery, List<CityDto>>
    {
        private readonly IAppDBContext applicationDbContext;

        public GetCityByIdQueryHandller(IAppDBContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<List<CityDto>> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        {
            var model = request.Id;
            var stateList = await applicationDbContext
                                    .Set<Domain.City>()
                                    .Where(a => a.StateId == model && !a.IsDelete)
                                    .ToListAsync();

            if (stateList == null || !stateList.Any())
            {
                return new List<CityDto>(); // Return an empty list if no states are found
            }

            return stateList.Adapt<List<CityDto>>();
        }
    }
}
