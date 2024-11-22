using App.core.Dto;
using App.core.Interface;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Core.Apps.Pateint.Query
{
  public class GetPateintQuery : IRequest<List<PateintDto>>
  {
    }

  public class GetPateintQueryHandler : IRequestHandler<GetPateintQuery, List<PateintDto>>
  {
    private readonly IAppDBContext appDbContext;
    public GetPateintQueryHandler(IAppDBContext _appDbContext)
    {
      appDbContext = _appDbContext;
    }
    public async Task<List<PateintDto>> Handle(GetPateintQuery request, CancellationToken cancellationToken)
    {
           
      var list =await appDbContext.Set<Domain.Pateints>().Where(a=>a.IsDelete==false && a.IsActive==true)
         .AsNoTracking()
         .ToListAsync();

            return list.Adapt<List<PateintDto>>();
    }
  }

}
