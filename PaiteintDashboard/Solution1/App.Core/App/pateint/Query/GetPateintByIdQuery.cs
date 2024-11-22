using App.Core.Dto;
using App.Core.Interface;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.App.pateint.Query
{
    public class GetPateintByIdQuery :IRequest<PateintDto>
    {
        public int Id { get; set; }
    }
    public class GetPateintQueryHandller : IRequestHandler<GetPateintByIdQuery , PateintDto>
    {
        private readonly IAppDbContext _appDbContext;

        public GetPateintQueryHandller(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<PateintDto> Handle(GetPateintByIdQuery request, CancellationToken cancellationToken)
        {
            var model = request.Id;

            var findid = await _appDbContext.Set<Domain.Pateint>().FindAsync(model);

            if(findid != null)
            {
                return findid.Adapt<PateintDto>();
            }
            return null;
        }
    }
}
