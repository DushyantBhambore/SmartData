using App.core.Dto;
using App.core.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.core.App.Country.Command
{
    public class UpdateCountryCommand : IRequest<string>
    {
        public CountryDto Country { get; set; }
    }
    public class UpdateCountryCommandHandller : IRequestHandler<UpdateCountryCommand, string>
    {
        private readonly IAppDBContext applicationDbContext;

        public UpdateCountryCommandHandller(IAppDBContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<string> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            var model = request.Country;

            var obj = applicationDbContext.Set<Domain.Country>().Find(model.CountryId);
            if (obj != null)
            {
                obj.IsActive = model.IsActive;
                obj.IsDelete = model.IsDelete;
                obj.CounrtyName = model.CounrtyName;
        await applicationDbContext.SaveChangesAsync();
                // Return a proper JSON response
                return "{\"message\":\"Id Updated Successfully\"}";
            }
            return "{\"message\":\"Patient not found\"}";
        }
    }
}
