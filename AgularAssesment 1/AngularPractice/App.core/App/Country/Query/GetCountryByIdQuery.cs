using App.core.Dto;
using App.core.Interface;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.Country.Query
{
    public class GetCountryByIdQuery : IRequest<CountryDto>
    {
        public int Id { get; set; }
    }

    public class GetCountryByIdQueryHandller : IRequestHandler<GetCountryByIdQuery, CountryDto>
    {
        private readonly IAppDBContext applicationDbContext;
        public GetCountryByIdQueryHandller(IAppDBContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<CountryDto> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
        {
            var model = request.Id;


            var customerid = await applicationDbContext.Set<Domain.Country>().FindAsync(model);
            if (model == null || customerid.IsDelete== true)
            {
                return null;
            }
            return customerid.Adapt<CountryDto>();
        }
    }
}
