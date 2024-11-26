using App.Core.Dto;
using App.Core.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App.Core.Apps.Role.Command
{
    public class AddRoleCommand : IRequest<string>
    {
        public RoleDto RoleDto { get; set; }
    }
    public class AddRoleCommandHandller : IRequestHandler<AddRoleCommand, string>
    {
        private readonly IAppDbContext _appDbContext;

        public AddRoleCommandHandller(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<string> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {

            var checkroleid = await _appDbContext.Set<Domain.Roles>()
                .Where(x=>x.RoleId==request.RoleDto.RoleId).
                FirstOrDefaultAsync();
            
            if(checkroleid == null )
            {
                var newrole = new Domain.Roles
                {
                    RoleId = request.RoleDto.RoleId,
                    RoleName = request.RoleDto.RoleName,
                    CreatedBy = "Admin",
                    CreatedOn = DateTime.Now,
                    IsActive = true,
                    IsDeletd = false,
                };
                await _appDbContext.Set<Domain.Roles>().AddAsync(newrole);
                await _appDbContext.SaveChangesAsync(cancellationToken);
            }

            else if (checkroleid.RoleId>0 && checkroleid.IsActive == true)
            {
                checkroleid.RoleId = request.RoleDto.RoleId;
                checkroleid.RoleName = request.RoleDto.RoleName;
                checkroleid.UpdateBy = "Admin";
                checkroleid.UpdatedOn = DateTime.Now;
                checkroleid.IsDeletd = false;
                checkroleid.IsActive = true;
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return JsonSerializer.Serialize(new { message = "Role is Updated  " });
            }

           
            return JsonSerializer.Serialize(new { message = "Role is created "});
           
        }
    }
}
