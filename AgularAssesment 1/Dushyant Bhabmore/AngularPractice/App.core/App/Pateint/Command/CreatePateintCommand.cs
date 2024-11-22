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
        public Domain.Pateints Pateint { get; set; }
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
           

            //var student = model.Adapt<Domain.Employee>();

            await _applicationDbContext.Set<Domain.Pateints>().AddAsync(model);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return model.PateintId;
        }
    }

}
