using App.Core.Dtos;
using App.Core.Interface;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.Role.Query
{
    public class GetAllRoleQuery : IRequest<List<RoleDto>>
    {
    }
    public class GetAllRoleQueryHandller : IRequestHandler<GetAllRoleQuery, List<RoleDto>>
    {
        private readonly IAppDbContext _appDbContext;
        public GetAllRoleQueryHandller(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<RoleDto>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            var  list  = await _appDbContext.Set<Domain.Role>().AsTracking().ToListAsync();
            return list.Adapt<List<RoleDto>>();
        }
    }
}
