using App.Core.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace App.Core.Apps.Patient.Command
{
    public class DeletePatientCommand : IRequest<string>
    {
        public int id { get; set; }
    }
    public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, string>
    {
        private readonly IAppDbContext _context;

        public DeletePatientCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var checkid = await _context.Set<Domain.Patient>().Where(a => a.PId == request.id && a.IsACtive == true).FirstOrDefaultAsync();

            if (checkid == null)
            {
                return JsonSerializer.Serialize(new
                {
                    message = "Id Not Found"
                });
            }

            checkid.IsACtive = false;
            checkid.IsDeleted = true;
            await _context.SaveChangesAsync();
            return JsonSerializer.Serialize(new
            {
                message = "Id Deleted Successfully"
            });
        }
    }

}
