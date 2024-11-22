using App.core.Dto;
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
    public class GetCustomerByIdQuery : IRequest<CustomerDto>
    {
        public int Id { get; set; }
    }

    public class GetCustomerByIdQueryHandller : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
    {
        private readonly IAppDBContext applicationDbContext;

        public GetCustomerByIdQueryHandller(IAppDBContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var model = request.Id;


            var customerid = await applicationDbContext.Set<Domain.Customers>().FindAsync(model);
            if (model == null || customerid.IsDelete== true)
            {
                return null;
            }
            return customerid.Adapt<CustomerDto>();
        }
    }
}
