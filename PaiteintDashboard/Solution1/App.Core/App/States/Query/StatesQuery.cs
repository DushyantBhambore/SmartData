using App.Core.Dto;
using App.Core.Interface;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace App.Core.App.States.Query
{
    public class StatesQuery : IRequest<List<StateDto>>
    {
    }
    public class StatesQueryHandler : IRequestHandler<StatesQuery, List<StateDto>>
    {
        private readonly IAppDbContext _appDbContext;

        public StatesQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<StateDto>> Handle(StatesQuery request, CancellationToken cancellationToken)
        {
            var state = await _appDbContext.Set<Domain.States>().AsTracking().ToListAsync();
            return state.Adapt<List<StateDto>>() ;

        }
    }
}
