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

namespace App.Core.App.pateint.Query
{
    public class GetAllPateintQuery : IRequest<List<PateintDto>>
    {
    }

    public class GetAllPateintHandller: IRequestHandler<GetAllPateintQuery,List<PateintDto>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetAllPateintHandller(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<PateintDto>> Handle(GetAllPateintQuery request, CancellationToken cancellationToken)
        {
            var pateintlist = await _appDbContext.Set<Domain.Pateint>().AsTracking().ToListAsync();
            return pateintlist.Adapt<List<PateintDto>>();
        }
    }
}
