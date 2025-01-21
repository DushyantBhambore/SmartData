using App.Core.Interface;
using Doamin.ResponseModal;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.App.Role.Query
{
    public class GetAllRoleQuery : IRequest<JsonModal>
    {
    }
    public class GetAllRoleQueryHandller : IRequestHandler<GetAllRoleQuery, JsonModal>
    {
        private readonly IAppDbContext _appDbContext;

        private readonly ILogger<GetAllRoleQueryHandller> _logger;

        public GetAllRoleQueryHandller(IAppDbContext appDbContext, ILogger<GetAllRoleQueryHandller> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task<JsonModal> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {

            var result = await _appDbContext.Set<Doamin.Role>().ToListAsync(cancellationToken);
            _logger.LogInformation("Get All Roles");
            return new JsonModal((int)HttpStatusCode.OK, "Get All Roles", result);
        }
    }
}
