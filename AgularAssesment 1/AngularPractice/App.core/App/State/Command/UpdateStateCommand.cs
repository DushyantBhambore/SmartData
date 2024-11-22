using App.core.Dto;
using App.core.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.core.App.Customer.Command
{
    public class UpdateStateCommand : IRequest<string>
    {
        public StateDto State { get; set; }
    }
    public class UpdateStateCommandHandller : IRequestHandler<UpdateStateCommand, string>
    {
        private readonly IAppDBContext applicationDbContext;

        public UpdateStateCommandHandller(IAppDBContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<string> Handle(UpdateStateCommand request, CancellationToken cancellationToken)
        {
            var model = request.State;

            var obj = applicationDbContext.Set<Domain.State>().Find(model.StateId);
            if (obj != null)
            {
               
                obj.StateName = model.StateName;
                obj.IsActive = model.IsActive;
                obj.IsDelete = model.IsDelete;
        await applicationDbContext.SaveChangesAsync();
                // Return a proper JSON response
                return "{\"message\":\"Id Updated Successfully\"}";
            }
            return "{\"message\":\"State not found\"}";
        }
    }
}
