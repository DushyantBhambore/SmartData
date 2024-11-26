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

namespace App.Core.Apps.Patient.Query
{
    public class GetAllPatient : IRequest<List<PatientDto>>
    {
    }
    public class GetAllPatientQuery : IRequestHandler<GetAllPatient , List<PatientDto>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetAllPatientQuery(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<PatientDto>> Handle(GetAllPatient request, CancellationToken cancellationToken)
        {
            var list = await _appDbContext.Set<Domain.Patient>().AsTracking().ToListAsync();
            return list.Adapt<List<PatientDto>>();
        }
    }
}
