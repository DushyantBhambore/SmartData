using App.Core.Dtos;
using App.Core.Interface;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.State.Command
{
    public class AddStateCommand : IRequest<object>
    {
        public StateDto StateDto { get; set; }
    }
    public class AddStateCommandHandler : IRequestHandler<AddStateCommand, object>
    {

        private readonly IAppDbContext _appDbContext;

        public AddStateCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<object> Handle(AddStateCommand request, CancellationToken cancellationToken)
        {

            var checkstate =await _appDbContext.Set<Domain.State>().Where(x => x.StateName == request.StateDto.StateName).FirstOrDefaultAsync();

            if (checkstate != null)
            {
                return new { message = "State already exist" };
            }

            var state = new Domain.State()
            {
                StateName = request.StateDto.StateName,
                CountryId = request.StateDto.CountryId
            };

            await _appDbContext.Set<Domain.State>().AddAsync(state);
            await _appDbContext.SaveChangesAsync();
            return new { message = "State added successfully" };

        }
    }
}
