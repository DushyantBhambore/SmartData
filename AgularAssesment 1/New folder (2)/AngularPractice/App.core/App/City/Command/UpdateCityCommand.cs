using App.core.Dto;
using App.core.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.core.App.City.Command
{
    public class UpdateCityCommand :IRequest<string>
    {
        public CityDto City { get; set; }
    }
    public class UpdateCityCommandHandller : IRequestHandler<UpdateCityCommand, string>
    {
        private readonly IAppDBContext applicationDbContext;

        public UpdateCityCommandHandller(IAppDBContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<string> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var model = request.City;

            var obj = applicationDbContext.Set<Domain.City>().Find(model.CityId);
            if (obj != null)
            {
               
                obj.CityName = model.CityName;
                obj.IsActive = model.IsActive;
                obj.IsDelete = model.IsDelete;
        await applicationDbContext.SaveChangesAsync();
                // Return a proper JSON response
                return "{\"message\":\"Id Updated Successfully\"}";
            }
            return "{\"message\":\"City not found\"}";
        }
    }
}
