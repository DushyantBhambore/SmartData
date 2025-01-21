using App.Core.Dto;
using App.Core.Interface;
using AutoMapper;
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

namespace App.Core.App.Role.Command
{
    public class AddRoleCommand : IRequest<JsonModal>
    {
        public RoleDto RoleDto { get; set; }
    }
    public  class AddRoleCommandHandler : IRequestHandler<AddRoleCommand, JsonModal>
    {
        private readonly IAppDbContext _appDbContext;
        private readonly ILogger<AddRoleCommandHandler> _logger;
        private readonly IMapper _mapper;

        public AddRoleCommandHandler(IAppDbContext appDbContext, IMapper mappe, ILogger<AddRoleCommandHandler> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
            _mapper = mappe;
        }

        public async Task<JsonModal> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var checkrole = await _appDbContext.Set<Doamin.Role>().
                Where(a => a.RoleId == request.RoleDto.RoleId).FirstOrDefaultAsync();
            if ( checkrole != null)
            {
                 _logger.LogError("Role already exist");
                return  new JsonModal((int)HttpStatusCode.Conflict, "Role already exist", null);
            }
            //var role = new Doamin.Role
            //{
            //    RoleId = request.RoleDto.RoleId,
            //    RoleName = request.RoleDto.RoleName
            //};

            var role = _mapper.Map<Doamin.Role>(request.RoleDto);
             _appDbContext.Set<Doamin.Role>().Add(role);
            await _appDbContext.SaveChangesAsync();
            _logger.LogInformation("Role Added successfully");
            return new JsonModal((int)HttpStatusCode.OK, "Role Added successfully", null);

        }
    }
}
