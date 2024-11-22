using App.Core.Dtos;
using App.Core.Interface;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.State.Query
{
    public class GeAllStateQuery : IRequest<List<StateDto>>
    {
    }
    public class GeAllStateQueryHandler : IRequestHandler<GeAllStateQuery, List<StateDto>>
    {
        private readonly IAppDbContext _appDbContext;

        public GeAllStateQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<StateDto>> Handle(GeAllStateQuery request, CancellationToken cancellationToken)
        {
            var list = await _appDbContext.Set<Domain.State>().AsTracking().ToListAsync(cancellationToken);
            return list.Adapt<List<StateDto>>();
                
        }
    }
}
