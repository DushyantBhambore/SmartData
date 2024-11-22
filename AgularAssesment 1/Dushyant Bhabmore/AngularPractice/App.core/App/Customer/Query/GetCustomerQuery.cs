using App.core.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Core.Apps.Customer.Query
{
  public class GetCustomerQuery : IRequest<List<Domain.Customers>>
  {

  }

  public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, List<Domain.Customers>>
  {
    private readonly IAppDBContext appDbContext;
    public GetCustomerQueryHandler(IAppDBContext _appDbContext)
    {
      appDbContext = _appDbContext;
    }
    public async Task<List<Domain.Customers>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {

      return await appDbContext.Set<Domain.Customers>()
    .AsNoTracking()
    .ToListAsync();
    }
  }

}
