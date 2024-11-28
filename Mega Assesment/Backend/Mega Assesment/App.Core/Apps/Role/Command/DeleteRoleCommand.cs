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
    public class DeleteRoleCommand : IRequest<object>
    {
        public int id { get; set; }
    }
    public class DeleteRoleCommandValidator :IRequestHandler<DeleteRoleCommand, object>
    {
        private readonly IAppDbContext _appDbContext;
        public DeleteRoleCommandValidator(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<object> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {

            var checkroleid  = await _appDbContext.Set<Domain.Role>().Where(x => x.RoleId == request.id && x.IsActive == true).FirstOrDefaultAsync();
            if (checkroleid == null)
            {
                return new { status = "Error", message = "Role not found" };
            }

            checkroleid.IsActive = false;
            checkroleid.IsDeleted = true;
            await _appDbContext.SaveChangesAsync();
            return new { status = "Success", message = "Role deleted successfully" };

        }
    }
}
