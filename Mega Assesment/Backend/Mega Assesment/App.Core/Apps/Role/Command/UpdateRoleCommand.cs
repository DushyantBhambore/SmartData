using App.Core.Dtos;
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
    public class UpdateRoleCommand : IRequest<object>
    {
        public RoleDto  RoleDto { get; set; }
    }
    public class UpdateRoleCommandHandller : IRequestHandler<UpdateRoleCommand, object>
    {
        private readonly IAppDbContext _appDbContext;
        public UpdateRoleCommandHandller(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<object> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {

            var checkroleid = await _appDbContext.Set<Domain.Role>().Where(x => x.RoleId == request.RoleDto.RoleId && x.IsActive == true).FirstOrDefaultAsync();

            if (checkroleid == null)
            {
                return new { status = "Error", message = "Role not found" };
            }
            checkroleid.RoleName = request.RoleDto.RoleName;
            await _appDbContext.SaveChangesAsync();
            return new { status = "Success", message = "Role updated successfully" };
        }
    }
}
