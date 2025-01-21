using App.Core.Dto;
using App.Core.Interface;
using Doamin.ResponseModal;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.App.User.Command
{
    public class ChangePasswordCommand : IRequest<JsonModal>
    {
        public ChangePasswordDto ChangePasswordDto { get; set; }
    }
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, JsonModal>
    {
        private readonly IAppDbContext _context;
        private  readonly ILogger<ChangePasswordCommandHandler> _logger;

        public ChangePasswordCommandHandler(IAppDbContext context, ILogger<ChangePasswordCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<JsonModal> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var model = request.ChangePasswordDto;
            var user = await _context.Set<Doamin.User>()
                .FirstOrDefaultAsync(x => x.UserName == request.ChangePasswordDto.UserName);
            if (user == null)
            {
                _logger.LogError("Username is Invalid");
                return new JsonModal((int)HttpStatusCode.BadRequest, "Username is Invalid", request.ChangePasswordDto.UserName);
            }


            if (request.ChangePasswordDto.ConfirmPassword != request.ChangePasswordDto.NewPassword)
            {
                _logger.LogError("Password is not Matched ");
                return new JsonModal((int)HttpStatusCode.BadRequest, "Password is not Matched ", null);
            }
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.NewPassword);

            user.Password = hashedPassword;
            await _context.SaveChangesAsync();
            //_context.Set<Domain.User>().Update(user);
            _logger.LogInformation("Password Changes SuccessFully");
            return new JsonModal((int)HttpStatusCode.OK, "Password Changes SuccessFully", null);
        }

    }
}
