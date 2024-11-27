using App.Core.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App.Core.Apps.Practitioner.Command
{
    public class DeletePractitonerCommand : IRequest<string>
    {
        public int id { get; set; }
    }
    public class DeletePractiionerCommandHandller : IRequestHandler<DeletePractitonerCommand, string>
    {
        private readonly IAppDbContext _appDbContext;
        public DeletePractiionerCommandHandller(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<string> Handle(DeletePractitonerCommand request, CancellationToken cancellationToken)
        {

            var patientid = await _appDbContext.Set<Domain.Practitioner>().FirstOrDefaultAsync(a => a.PractitionerID == request.id && a.IsActive == true);

            if (patientid == null)
            {
                return JsonSerializer.Serialize(new { message = "Invalid Patient Id" });
            }
            else
            {
                patientid.IsActive = false;
                patientid.IsDeletd = true;
                patientid.DeletedBy = "Admin";
                patientid.DeletedOn = DateTime.Now;

                var userid = _appDbContext.Set<Domain.User>().FirstOrDefault(a => a.UserId == patientid.UserId && patientid.IsActive == true);
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


