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

namespace App.Core.Apps.Agent.Query
{
    public class GetAllAgentQuery : IRequest<List<AgentDto>>
    {
    }
    public class GetAllAgentQueryHandller : IRequestHandler<GetAllAgentQuery,List<AgentDto>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetAllAgentQueryHandller(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<AgentDto>> Handle(GetAllAgentQuery request, CancellationToken cancellationToken)
        {
            var list = await _appDbContext.Set<Domain.Agent>().AsTracking().ToListAsync();
            return list.Adapt<List<AgentDto>>();
        }
    }
}
