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

namespace App.Core.Apps.Practitioner.Query
{
    public class GetAllPractitionerQuery : IRequest<List<PractitionerDto>>
    {
    }
    public class GetAllPractitionerQueryHandller : IRequestHandler<GetAllPractitionerQuery, List<PractitionerDto>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetAllPractitionerQueryHandller(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<PractitionerDto>> Handle(GetAllPractitionerQuery request, CancellationToken cancellationToken)
        {
            var list = await _appDbContext.Set<Domain.Practitioner>().AsTracking().ToListAsync();
            return list.Adapt<List<PractitionerDto>>();
        }
    }
}
