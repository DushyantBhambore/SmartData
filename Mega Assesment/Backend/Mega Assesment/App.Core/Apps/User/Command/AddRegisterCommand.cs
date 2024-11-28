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

namespace App.Core.Apps.User.Command
{
    public class AddRegisterCommand : IRequest<object>
    {
        public RegisterDto  RegisterDto { get; set; }
    }

    public class AddRegisterCommandHandler : IRequestHandler<AddRegisterCommand, object>
    {
        private readonly IAppDbContext _appDbContext;

        private readonly IEmailService _emailService;
        public AddRegisterCommandHandler(IAppDbContext appDbContext, IEmailService emailService)
        {
            _appDbContext = appDbContext;
            _emailService = emailService;
        }
        public async Task<object> Handle(AddRegisterCommand request, CancellationToken cancellationToken)
        {

            var checkemail = await _appDbContext.Set<Domain.User>().Where(x=>x.Email==request.RegisterDto.Email).FirstOrDefaultAsync();

            if (checkemail != null)
            {
                return new { message = "Email already exist" };
            }

            // Generate Username
            string formattedDOB = request.RegisterDto.DOB.ToString("ddMMyy");
            string username = $"EC_{request.RegisterDto.LastName.ToUpper()}{request.RegisterDto.FirstName.ToUpper()[0]}{formattedDOB}";

            // Generate Password
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string password = new string(Enumerable.Repeat(chars, 8).Select(s => s[new Random().Next(s.Length)]).ToArray());

            // Encrypt Username and Password
            string encryptedUsername = Encrypt(username);
            string encryptedPassword = Encrypt(password);

            // Create new user
            var user = new Domain.User
            {
                FirstName = request.RegisterDto.FirstName,
                LastName = request.RegisterDto.LastName,
                Email = request.RegisterDto.Email,
                UserTypeId = request.RegisterDto.UserTypeId,
                DOB = request.RegisterDto.DOB,
                Mobile = request.RegisterDto.Mobile,
                Address = request.RegisterDto.Address,
                Zipcode = request.RegisterDto.Zipcode,
                StateId = request.RegisterDto.StateId,
                CountryId = request.RegisterDto.CountryId,
                ProfileImage = request.RegisterDto.ProfileImage,
                Username = encryptedUsername,
                Password = encryptedPassword
            };

            await _appDbContext.Set<Domain.User>().AddAsync(user);
            await _appDbContext.SaveChangesAsync();
            await _emailService.SendEmailAsync(checkemail.Email, "Welcome to Our Application", $"Hello {request.RegisterDto.FirstName},\n\nYour account has been created successfully.\n\nUsername: {username}\nPassword: {password}\n\nRegards,\nTeam");

            return new { message = "User added successfully" };

        }

        private string Encrypt(string input)
        {
            // Simplified encryption for illustration
            byte[] data = System.Text.Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(data);
        }
    }
}
