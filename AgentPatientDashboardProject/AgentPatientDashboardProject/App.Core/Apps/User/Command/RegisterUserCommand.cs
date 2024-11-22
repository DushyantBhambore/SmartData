using App.Core.Dtos;
using App.Core.Interface;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Core.Apps.User.Command
{
    public class RegisterUserCommand : IRequest<RegisterDto>
    {
        public RegisterDto register { get; set; }
    }
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterDto>
    {
        private readonly IAppDbContext _appdbcontext;

        public RegisterUserCommandHandler(IAppDbContext appdbcontext)
        {
            _appdbcontext = appdbcontext;
        }
        public async Task<RegisterDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var checkemail = await _appdbcontext.Set<Domain.User>().FirstOrDefaultAsync(x => x.Email == request.register.Email);

            if ((checkemail != null))
            {
                return null;
            }

            var lastangent = await _appdbcontext.Set<Domain.User>().OrderByDescending(x => x.AgentId).FirstOrDefaultAsync();
            string newagentid;

            if (lastangent == null)
            {
                newagentid = "PE001";
            }
            else
            {
                var value = int.Parse(lastangent.AgentId.Substring(2));
                newagentid = "PE" + (value + 1).ToString("D3");

            }

            var hashpassword = BCrypt.Net.BCrypt.HashPassword(request.register.Password);

            var user = new Domain.User
            {
                UserId = request.register.UserId,
                AgentId = newagentid,
                FirstName = request.register.FirstName,
                LastName = request.register.LastName,
                Email = request.register.Email,
                Password = hashpassword,
                ConfirmPassword = request.register.Password,
            };

            await _appdbcontext.Set<Domain.User>().AddAsync(user);
            await _appdbcontext.SaveChangesAsync(cancellationToken);

            return user.Adapt<RegisterDto>();
        }
    }
}
