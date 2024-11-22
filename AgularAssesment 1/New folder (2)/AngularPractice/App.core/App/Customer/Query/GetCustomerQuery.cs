using App.core.Dto;
using App.core.Interface;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Core.Apps.Customer.Query
{
  public class GetCustomerQuery : IRequest<List<CustomerDto>>
  {

  }

  public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, List<CustomerDto>>
  {
    private readonly IAppDBContext appDbContext;
    public GetCustomerQueryHandler(IAppDBContext _appDbContext)
    {
      appDbContext = _appDbContext;
    }
    public async Task<List<CustomerDto>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {

      var list = await appDbContext.Set<Domain.Customers>().Where(a=>a.IsDelete==false && a.IsActive==true)
    .AsNoTracking()
    .ToListAsync();

            return list.Adapt<List<CustomerDto>>().ToList();
    }
  }

}
