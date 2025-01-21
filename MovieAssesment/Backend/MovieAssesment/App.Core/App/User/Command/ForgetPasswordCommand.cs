using App.Core.App.User.Command;
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
    public class ForgetPasswordCommand : IRequest<JsonModal>
    {
        public ForgotPasswordDto forgotEamilDto { get; set; }

}
public class ForgetPasswordCommandHandler : IRequestHandler<ForgetPasswordCommand, JsonModal>
{
    private readonly IAppDbContext _context;
    private readonly IEmailService _emailService;
        private readonly ILogger<ForgetPasswordCommandHandler> _logger;
    public ForgetPasswordCommandHandler(IAppDbContext context, IEmailService emailService, ILogger<ForgetPasswordCommandHandler> logger)
    {
        _context = context;
        _emailService = emailService;
            _logger = logger;
    }
    public async Task<JsonModal> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
    {
        //var email = request.Email.Trim().ToLower();
        var user = await _context.Set<Doamin.User>().FirstOrDefaultAsync(x => x.Email == request.forgotEamilDto.Email, cancellationToken);

        if (user == null)
        {
                _logger.LogError("Invalid Email");
            return new JsonModal((int)HttpStatusCode.BadRequest, "Invalid Email", request.forgotEamilDto.Email);
        }

        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        string password = new string(Enumerable.Repeat(chars, 8).Select(s => s[new Random().Next(s.Length)]).ToArray());


        user.Password = BCrypt.Net.BCrypt.HashPassword(password);
        _context.Set<Doamin.User>().Update(user);

        await _context.SaveChangesAsync(cancellationToken);

        await _emailService.SendEmailAsync(user.Email, "Password Reset", $"Your new password is {password}");
            _logger.LogInformation("Password Sent To Your Mail ");
            return new JsonModal((int)HttpStatusCode.OK, "Password Sent To Your Mail ", user.Password);
    }
}
}
