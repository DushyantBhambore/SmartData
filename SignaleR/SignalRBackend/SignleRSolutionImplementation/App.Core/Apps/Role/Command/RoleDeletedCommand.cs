using App.Core.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.Role.Command
{
    public class RoleDeletedCommand : IRequest<string>
    {
        public int id { get; set; }
    }
    public class RoleDeleteCommandHandller : IRequestHandler<RoleDeletedCommand,string>
    {
        private readonly IAppDbContext _appDbContext;

        public RoleDeleteCommandHandller(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<string> Handle(RoleDeletedCommand request, CancellationToken cancellationToken)
        {
            var checkid = await _appDbContext.Set<Domain.Roles>().FirstOrDefaultAsync(a => a.RoleId == request.id);

            if (checkid == null)
            {
                return "Id Is Not Exists";
            }

            throw new NotImplementedException();
        }
    }

}
