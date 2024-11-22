using App.core.Dto;
using App.core.Interface;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Core.Apps.City.Query
{
  public class GetCityQuery : IRequest<List<CityDto>>
  {

  }

  public class GetCustomerQueryHandler : IRequestHandler<GetCityQuery, List<CityDto>>
  {
    private readonly IAppDBContext appDbContext;
    public GetCustomerQueryHandler(IAppDBContext _appDbContext)
    {
      appDbContext = _appDbContext;
    }
    public async Task<List<CityDto>> Handle(GetCityQuery request, CancellationToken cancellationToken)
    {

      var list = await appDbContext.Set<Domain.City>().Where(a=>a.IsDelete==false && a.IsActive==true)
    .AsNoTracking()
    .ToListAsync();

            return list.Adapt<List<CityDto>>();
    }
  }

}
