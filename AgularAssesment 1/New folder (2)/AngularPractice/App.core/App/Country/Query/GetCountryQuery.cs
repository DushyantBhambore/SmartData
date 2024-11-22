using App.core.Dto;
using App.core.Interface;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Core.Apps.Country.Query
{
  public class GetCountryQuery : IRequest<List<CountryDto>>
  {

  }
  public class GetCountryQueryHandler : IRequestHandler<GetCountryQuery, List<CountryDto>>
  {
    private readonly IAppDBContext appDbContext;
    public GetCountryQueryHandler(IAppDBContext _appDbContext)
    {
      appDbContext = _appDbContext;
    }
    public async Task<List<CountryDto>> Handle(GetCountryQuery request, CancellationToken cancellationToken)
    {

      var list = await appDbContext.Set<Domain.Country>().Where(a=>a.IsDelete==false && a.IsActive==true)
    .AsNoTracking()
    .ToListAsync();

            return list.Adapt<List<CountryDto>>();
    }
  }

}
