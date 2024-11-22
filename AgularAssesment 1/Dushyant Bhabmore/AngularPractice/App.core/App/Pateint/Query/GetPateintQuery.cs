using App.core.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Core.Apps.Pateint.Query
{
  public class GetPateintQuery : IRequest<List<Domain.Pateints>>
  {

  }

  public class GetPateintQueryHandler : IRequestHandler<GetPateintQuery, List<Domain.Pateints>>
  {
    private readonly IAppDBContext appDbContext;
    public GetPateintQueryHandler(IAppDBContext _appDbContext)
    {
      appDbContext = _appDbContext;
    }
    public async Task<List<Domain.Pateints>> Handle(GetPateintQuery request, CancellationToken cancellationToken)
    {

      return await appDbContext.Set<Domain.Pateints>()
    .AsNoTracking()
    .ToListAsync();
    }
  }

}
