using App.core.Dto;
using App.core.Interface;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.State.Query
{
    public class GetStateByIdQuery : IRequest<StateDto>
    {
        public int Id { get; set; }
    }

    public class GetStateByIdQueryHandller : IRequestHandler<GetStateByIdQuery, StateDto>
    {
        private readonly IAppDBContext applicationDbContext;

        public GetStateByIdQueryHandller(IAppDBContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<StateDto> Handle(GetStateByIdQuery request, CancellationToken cancellationToken)
        {
            var model = request.Id;
            var customerid = await applicationDbContext.Set<Domain.State>().FindAsync(model);
            if (model == null || customerid.IsDelete== true)
            {
                return null;
            }
            return customerid.Adapt<StateDto>();
        }
    }
}
