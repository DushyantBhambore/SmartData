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
    public class DeleteUserCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
    public class DeleteUserCommandHandller : IRequestHandler<DeleteUserCommand, string>
    {
        private readonly IAppDbContext _appDbContext;

        public DeleteUserCommandHandller(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<string> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {

            var checkid = await _appDbContext.Set<Domain.User>().FirstOrDefaultAsync(a => a.UserId == request.Id && a.IsActive==true && a.IsDelete==false);
            if(checkid == null)
            {
                return JsonSerializer.Serialize(new { message = "Invalid Credential" });
            }
            checkid.IsActive = false;
            checkid.IsDelete = true;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return JsonSerializer.Serialize(new { message = "User Deleted SuccessFully" });

        }
    }
}
