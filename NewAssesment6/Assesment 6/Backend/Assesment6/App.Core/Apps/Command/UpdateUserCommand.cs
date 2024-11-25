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

namespace App.Core.Apps.Command
{
    public class UpdateUserCommand : IRequest<string>
    {
        public UserDto UserDto { get; set; }
    }
    public class UpdateUserCommandHandller : IRequestHandler<UpdateUserCommand, string>
    {
        private readonly IAppDbContext _appDbContext;

        public UpdateUserCommandHandller(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<string> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var checkuser = await _appDbContext.Set<Domain.User>()
                .Where(a => a.Email == request.UserDto.Email && a.IsActive == true && a.IsDelete == false)
                .FirstOrDefaultAsync();

            if (checkuser == null)
            {
                return JsonSerializer.Serialize(new { message = "Invalid Credential" });
            }
            checkuser.FirstName = request.UserDto.FirstName;
            checkuser.LastName = request.UserDto.LastName;
            checkuser.Country = request.UserDto.Country;
            checkuser.State = request.UserDto.State;
            checkuser.City= request.UserDto.City;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return JsonSerializer.Serialize(new {message ="Update Successfully ",data = checkuser});
        }
    }

}
