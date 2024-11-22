using App.core.Dto;
using App.core.Interface;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Core.Apps.Employee.Query
{
  public class GetEmployeeQuery : IRequest<List<EmployeeDto>>
  {

  }

  public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, List<EmployeeDto>>
  {
    private readonly IAppDBContext appDbContext;
    public GetEmployeeQueryHandler(IAppDBContext _appDbContext)
    {
      appDbContext = _appDbContext;
    }
    public async Task<List<EmployeeDto>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    {

     var list = await appDbContext.Set<Domain.Employee>().Where(a => a.IsDelete == false && a.IsActive == true)
    .AsNoTracking()
    .ToListAsync();

            return list.Adapt<List<EmployeeDto>>();
    }
  }

}
