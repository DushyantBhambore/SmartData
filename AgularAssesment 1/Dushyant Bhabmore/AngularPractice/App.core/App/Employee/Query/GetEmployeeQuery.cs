using App.core.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Core.Apps.Employee.Query
{
  public class GetEmployeeQuery : IRequest<List<Domain.Employee>>
  {

  }

  public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, List<Domain.Employee>>
  {
    private readonly IAppDBContext appDbContext;
    public GetEmployeeQueryHandler(IAppDBContext _appDbContext)
    {
      appDbContext = _appDbContext;
    }
    public async Task<List<Domain.Employee>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    {

      return await appDbContext.Set<Domain.Employee>()
    .AsNoTracking()
    .ToListAsync();
    }
  }

}
