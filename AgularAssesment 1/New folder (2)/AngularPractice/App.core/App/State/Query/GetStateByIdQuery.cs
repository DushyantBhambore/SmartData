using App.core.Dto;
using App.core.Interface;
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
        public int Id { get; set; }
    }

    public class GetStateByIdQueryHandler : IRequestHandler<GetStateByIdQuery, List<StateDto>>
    {
        private readonly IAppDBContext applicationDbContext;

        public GetStateByIdQueryHandler(IAppDBContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }

        public async Task<List<StateDto>> Handle(GetStateByIdQuery request, CancellationToken cancellationToken)
        {
            var model = request.Id;
            var stateList = await applicationDbContext
                                    .Set<Domain.State>()
                                    .Where(a => a.CountryId == model && !a.IsDelete)
                                    .ToListAsync();

            if (stateList == null || !stateList.Any())
            {
                return new List<StateDto>(); // Return an empty list if no states are found
            }

            return stateList.Adapt<List<StateDto>>();
        }
    }

}