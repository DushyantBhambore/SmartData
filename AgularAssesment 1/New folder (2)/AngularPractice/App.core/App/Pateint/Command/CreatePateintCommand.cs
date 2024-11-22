using App.core.Dto;
using App.core.Interface;
using Domain;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.core.App.Pateint.Command
{
    public class CreatePateintCommand : IRequest<int>
    {
        public PateintDto Pateint { get; set; }
    }

    public class CreatePateintCommandHandler : IRequestHandler<CreatePateintCommand, int>
    {
        private readonly IAppDBContext _applicationDbContext;

        public CreatePateintCommandHandler(IAppDBContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<int> Handle(CreatePateintCommand request, CancellationToken cancellationToken)
        {
            var model = request.Pateint;
           

            var pateint = model.Adapt<Domain.Pateints>();

            await _applicationDbContext.Set<Domain.Pateints>().AddAsync(pateint);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return model.PateintId;
        }
    }

}
