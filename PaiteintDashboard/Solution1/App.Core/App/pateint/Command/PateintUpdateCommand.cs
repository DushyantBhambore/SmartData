using App.Core.Dto;
using App.Core.Interface;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.App.pateint.Command
{
    public class PateintUpdateCommand :IRequest<string>
    {
        public PateintDto Pateint { get; set; }
    }

    public class PateintUpdateCommandHandller : IRequestHandler<PateintUpdateCommand, string>
    {
        private readonly IAppDbContext _appDbContext;

        public PateintUpdateCommandHandller(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<string> Handle(PateintUpdateCommand request, CancellationToken cancellationToken)
        {
            var model = request.Pateint;

            var updatepateint = _appDbContext.Set<Domain.Pateint>().Find(model.PId);
            if (updatepateint !=null)
            {

                updatepateint.AgentId = model.AgentId;
                updatepateint.FirstName = model.FirstName;
                updatepateint.LastName = updatepateint.LastName;
                updatepateint.DateOfBirth= model.DateOfBirth;
                updatepateint.PhoneNumber = model.PhoneNumber;
                updatepateint.AddressLine1 = model.AddressLine1;
                updatepateint.AddressLine2 = model.AddressLine2;
                updatepateint.AppoinmentDate = model.AppoinmentDate;
                updatepateint.BloodGroup = model.BloodGroup;
                updatepateint.Gender = model.Gender;
                updatepateint.Countries = model.Countries;
                updatepateint.States = model.States;
                updatepateint.City = model.City;
                updatepateint.IsActive = model.IsActive;
                updatepateint.IsDelete = model.IsDelete;
               await _appDbContext.SaveChangesAsync();

                return "{\"message\":\"Id Updated Successfully\"}";

            }
            return "{\"message\":\"Patient not found\"}";

        }
    }
}
