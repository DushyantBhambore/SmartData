using App.Core.Dtos;
using App.Core.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.Country.Command
{
    public class AddCountryCommand : IRequest<object>
    {
        public CountryDto  CountryDto { get; set; }
    }
    public class AddCountryCommandHandler : IRequestHandler<AddCountryCommand, object>
    {
        private readonly IAppDbContext _appDbContext;
        public AddCountryCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<object> Handle(AddCountryCommand request, CancellationToken cancellationToken)
        {

            var checkcountryname = await _appDbContext.Set<Domain.Country>().Where(x => x.CountryName == request.CountryDto.CountryName).FirstOrDefaultAsync();


            if (checkcountryname != null)
            {
                return new { message = "Country already exist" };
            }

            var country = new Domain.Country()
            {
                CountryName = request.CountryDto.CountryName
            };

            await _appDbContext.Set<Domain.Country>().AddAsync(country);
            await _appDbContext.SaveChangesAsync();
            return new { message = "Country added successfully" };
        }
    }

}
