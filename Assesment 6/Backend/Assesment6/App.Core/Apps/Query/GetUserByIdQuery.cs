using App.Core.Dto;
using App.Core.Interface;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App.Core.Apps.Query
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public int Id { get; set; }
    }
    public class GetUserByIdQueryHandller : IRequestHandler<GetUserByIdQuery,UserDto>
    {
        private readonly IAppDbContext _appDbContext;

        public GetUserByIdQueryHandller(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var getid = await _appDbContext.Set<Domain.User>().FirstOrDefaultAsync(a=>a.UserId == request.Id);

            if (getid == null)
            {
                return null;
            }
            return getid.Adapt<UserDto>();
        }
    }
}
