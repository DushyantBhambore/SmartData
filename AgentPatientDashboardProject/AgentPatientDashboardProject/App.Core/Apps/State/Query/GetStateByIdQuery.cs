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
    public class GetStateByIdQuery : IRequest<List<StateDto>>
    {
        public int id { get; set; }
    }
    public class GetStateByIdQueryHandler : IRequestHandler<GetStateByIdQuery, List<StateDto>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetStateByIdQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<StateDto>> Handle(GetStateByIdQuery request, CancellationToken cancellationToken)
        {
           var findid = _appDbContext.Set<Domain.State>().Where(x => x.CountryId == request.id).FirstOrDefault();

            if (findid == null)
            {
                return null;
            }
           var list = await _appDbContext.Set<Domain.State>().AsTracking().ToListAsync();

            return list.Adapt<List<StateDto>>();
        }
    }
}
