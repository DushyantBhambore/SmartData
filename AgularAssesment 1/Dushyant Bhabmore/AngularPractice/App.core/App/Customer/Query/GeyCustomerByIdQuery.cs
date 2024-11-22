using App.core.Interface;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.Customer.Query
{
    public class GeyCustomerByIdQuery : IRequest<Domain.Customers>
    {
        public int Id { get; set; }
    }

    public class GeyCustomerByIdQueryHandller : IRequestHandler<GeyCustomerByIdQuery, Domain.Customers>
    {
        private readonly IAppDBContext applicationDbContext;

        public GeyCustomerByIdQueryHandller(IAppDBContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<Domain.Customers> Handle(GeyCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var model = request.Id;


            var customerid = await applicationDbContext.Set<Domain.Customers>().FindAsync(model);
            if (model == null)
            {
                return null;
            }

            return customerid;
        }
    }
}
