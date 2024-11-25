using App.Core.Dto;
using App.Core.Interface;
using Dapper;
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
    }
    public class GetAllUserQueryHandller : IRequestHandler<GetAllUserQuery, List<UserDto>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetAllUserQueryHandller(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<UserDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            //var list = await _appDbContext.Set<Domain.User>().Where(a => a.IsDelete== false && a.IsActive == true).AsTracking().ToListAsync();
            //return list.Adapt<List<UserDto>>();
            using var connection = _appDbContext.GetConnection();
            var query = "SELECT * FROM [User] Where IsActive=1 And IsDelete=0;";
            var data = await connection.QueryAsync<UserDto>(query);
            return data.Adapt<List<UserDto>>().AsList();
        }
    }
}
