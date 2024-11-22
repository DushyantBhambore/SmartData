using App.Core.Dtos;
using App.Core.Interface;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.State.Command
{
    public class AddStateCommand : IRequest<StateDto>
    {
        public StateDto stateDto { get; set; }
    }
    public class AddStateCommandHandler : IRequestHandler<AddStateCommand, StateDto>
    {
        private readonly IAppDbContext _appDbContext;

        public AddStateCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<StateDto> Handle(AddStateCommand request, CancellationToken cancellationToken)
        {
            var state = new Domain.State
            {
                StateId = request.stateDto.StateId,
                StateName = request.stateDto.StateName,
                CountryId = request.stateDto.CountryId
            };

            await _appDbContext.Set<Domain.State>().AddAsync(state, cancellationToken);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return state.Adapt<StateDto>();
        }
    }
}
