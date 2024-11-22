using App.core.Dto;
using App.core.Interface;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Core.Apps.State.Query
{
  public class GetStateQuery : IRequest<List<StateDto>>
  {

  }

  public class GetStateQueryHandler : IRequestHandler<GetStateQuery, List<StateDto>>
  {
    private readonly IAppDBContext appDbContext;
    public GetStateQueryHandler(IAppDBContext _appDbContext)
    {
      appDbContext = _appDbContext;
    }
    public async Task<List<StateDto>> Handle(GetStateQuery request, CancellationToken cancellationToken)
    {

      var list = await appDbContext.Set<Domain.State>().Where(a=>a.IsDelete==false && a.IsActive==true)
    .AsNoTracking()
    .ToListAsync();

            return list.Adapt<List<StateDto>>();
    }
  }

}
