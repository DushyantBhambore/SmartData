using App.Core.Apps.Practitioner.Command;
using App.Core.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App.Core.Apps.Agent.Command
{
    public class DeleteAgentCommand : IRequest<string>
    {
        public int id { get; set; }
    }
    public class DeleteAgentCommandHandller : IRequestHandler<DeletePractitonerCommand, string>
    {
        private readonly IAppDbContext _appDbContext;

        public DeleteAgentCommandHandller(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<string> Handle(DeletePractitonerCommand request, CancellationToken cancellationToken)
        {
            var agentid = await _appDbContext.Set<Domain.Agent>().FirstOrDefaultAsync(a => a.AId == request.id && a.IsActive == true);

            if (agentid == null)
            {
                return JsonSerializer.Serialize(new { message = "Invalid Agent Id" });
            }
            else
            {
                agentid.IsActive = false;
                agentid.IsDeletd = true;
                agentid.DeletedBy = "Admin";
                agentid.DeletedOn = DateTime.Now;

                var userid = _appDbContext.Set<Domain.User>().FirstOrDefault(a => a.UserId == agentid.UserId && agentid.IsActive == true);
                if (userid == null)
                {
                    return JsonSerializer.Serialize(new { message = "Invalid User Id " });
                }
                else
                {
                    userid.IsActive = false;
                    userid.IsDeletd = true;
                    userid.DeletedBy = "Admin";
                    userid.DeletedOn = DateTime.Now;
                }
                await _appDbContext.SaveChangesAsync(cancellationToken);
            }
            return JsonSerializer.Serialize(new { message = "Id is Deleted Successfully" });
        }
    }
}
