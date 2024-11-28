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
    public class GetRoleByIdQuery : IRequest<List<StateDto>>
    {
        public int Id { get; set; }
    }
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, List<StateDto>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetRoleByIdQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<StateDto>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var list = await _appDbContext.Set<Domain.State>().Where(x => x.Id == request.Id).AsTracking().ToListAsync();
            return list.Adapt<List<StateDto>>();
        }
    }   
}
