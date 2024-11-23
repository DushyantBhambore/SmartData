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

namespace App.Core.Apps.Query
{
    public class GetAllUserQuery : IRequest<List<UserDto>>
    {
        public UserDto userDto { get; set; }
    }
    public class GetAllUserQueryHandller : IRequestHandler<GetAllUserQuery, List<UserDto>>
    {
        private readonly IAppDbContext _appDbContext;
        public async Task<List<UserDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var list = await _appDbContext.Set<Domain.User>().
                Where(a => a.IsActive == true && a.IsDelete == false).
                AsTracking().ToListAsync();
            return list.Adapt<List<UserDto>>();
        }
    }
}
