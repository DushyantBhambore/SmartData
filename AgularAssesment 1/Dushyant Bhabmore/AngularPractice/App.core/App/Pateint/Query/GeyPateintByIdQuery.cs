using App.core.Interface;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.Pateint.Query
{
    public class GeyPateintByIdQuery : IRequest<Domain.Pateints>
    {
        public int Id { get; set; }
    }

    public class GeyPateintByIdQueryHandller : IRequestHandler<GeyPateintByIdQuery, Domain.Pateints>
    {
        private readonly IAppDBContext applicationDbContext;

        public GeyPateintByIdQueryHandller(IAppDBContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<Domain.Pateints> Handle(GeyPateintByIdQuery request, CancellationToken cancellationToken)
        {
            var model = request.Id;


            var deptid = await applicationDbContext.Set<Domain.Pateints>().FindAsync(model);
            if (model == null)
            {
                return null;
            }

            return deptid;
        }
    }
}
