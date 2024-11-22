using App.core.Dto;
using App.core.Interface;
using Mapster;
using MediatR;


namespace App.Core.Apps.Pateint.Query
{
    public class GetPateintByIdQuery : IRequest<PateintDto>
    {
        public int Id { get; set; }
    }

    public class GeyPateintByIdQueryHandller : IRequestHandler<GetPateintByIdQuery, PateintDto>
    {
        private readonly IAppDBContext applicationDbContext;

        public GeyPateintByIdQueryHandller(IAppDBContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<PateintDto> Handle(GetPateintByIdQuery request, CancellationToken cancellationToken)
        {
            var model = request.Id;

            var deptid = await applicationDbContext.Set<Domain.Pateints>().FindAsync(model);
            if (model == null || deptid.IsDelete==true)
            {
                return null;
            }
           
            return deptid.Adapt<PateintDto>();
        }
    }
}
