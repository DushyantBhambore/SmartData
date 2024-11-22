using App.Core.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.App.pateint.Command
{
    public class PateintDeleteCommand : IRequest<int>
    {
        public int PateintId { get; set; }
    }

    public class PateintDeleteCommandHandler : IRequestHandler<PateintDeleteCommand, int>
    {
        private readonly IAppDbContext _appDbContext;

        public PateintDeleteCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> Handle(PateintDeleteCommand request, CancellationToken cancellationToken)
        {
            var pateint = _appDbContext.Set<Domain.Pateint>().Find(request.PateintId);
            if (pateint != null || pateint.IsDelete==true)
            {
                pateint.IsActive = false;
                pateint.IsDelete = true;
               await _appDbContext.SaveChangesAsync(cancellationToken);
              return  pateint.PId;

            }
            return 0; ;
        }
    }
}
