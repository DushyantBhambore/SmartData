using App.Core.Dto;
using App.Core.Interface;
using AutoMapper;
using Doamin.ResponseModal;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace App.Core.App.User.Command
{
    public class UpdateUserCommand : IRequest<JsonModal>
    {
        public registerDto  RegisterDto { get; set; }
    }
    public class UpdateUserCommandHandller : IRequestHandler<UpdateUserCommand, JsonModal>
    {
        private readonly IAppDbContext _appDbContext;
        private readonly ILogger<UpdateUserCommandHandller> _logger;
        private readonly IEmailService _emailService;

        private readonly IMapper _mapper;
public UpdateUserCommandHandller(IEmailService emailService,
   IMapper mapper ,ILogger<UpdateUserCommandHandller> logger,IAppDbContext appDbContext )
        {
            _emailService = emailService;
            _logger = logger;
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        public async Task<JsonModal> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var finduserid = await _appDbContext.Set<Doamin.User>().
             FirstOrDefaultAsync(a => a.UserId == request.RegisterDto.UserId);

            if (finduserid == null)
            {
                _logger.LogError("Invalid User Id ");    
                return new JsonModal((int)HttpStatusCode.BadRequest, "Invalid User Id ", null);
            }

            //finduserid.FirstName = request.RegisterDto.FirstName;
            //finduserid.LastName = request.RegisterDto.LastName;
            //finduserid.Email = request.RegisterDto.Email;
            //finduserid.DateOfBirth = request.RegisterDto.DateOfBirth;
            //finduserid.UpdatedBy = request.RegisterDto.FirstName + request.RegisterDto.LastName;
            //finduserid.UdatedOn = DateTime.Now;

            _mapper.Map(request.RegisterDto, finduserid);

            finduserid.UpdatedBy = request.RegisterDto.FirstName + request.RegisterDto.LastName;
            finduserid.UdatedOn = DateTime.Now;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            await _emailService.SendEmailAsync(finduserid.Email, "Updated Request", "Your Profile is Updated");
            _logger.LogInformation("User Profile Updated");
            return new JsonModal((int)(HttpStatusCode.OK), "User Profile Updated", finduserid);

        }
    }
}
