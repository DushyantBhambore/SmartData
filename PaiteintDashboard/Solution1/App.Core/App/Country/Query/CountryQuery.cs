using App.Core.Dto;
using App.Core.Interface;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.App.Country.Query
{
    public class CountryQuery : IRequest<List<CountryDto>>
    {
    }
    public class CountryQueryHandler : IRequestHandler<CountryQuery, List<CountryDto>>
    {
        private readonly IAppDbContext _appDbContext;

        public CountryQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<CountryDto>> Handle(CountryQuery request, CancellationToken cancellationToken)
        {
            var list = await _appDbContext.Set<Domain.Countries>().AsTracking().ToListAsync();

            return list.Adapt<List<CountryDto>>();
        }
    }
}
