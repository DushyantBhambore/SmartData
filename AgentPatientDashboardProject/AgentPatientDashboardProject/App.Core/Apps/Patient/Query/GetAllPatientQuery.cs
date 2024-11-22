using App.Core.Interface;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Core.Apps.Patient.Query
{
    public class GetAllPatientQuery : IRequest<List<Domain.Patient>>
    {
    }
    public class GetAllPatientQueryHandler : IRequestHandler<GetAllPatientQuery, List<Domain.Patient>>
    {
        private readonly IAppDbContext _appDbContext;
        public GetAllPatientQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<Domain.Patient>> Handle(GetAllPatientQuery request, CancellationToken cancellationToken)
        {
             var list =  await _appDbContext.Set<Domain.Patient>().Where(a=>a.IsACtive==true && a.IsDeleted==false).AsTracking().ToListAsync();
            return list.Adapt<List<Domain.Patient>>();
        }
    }
}
