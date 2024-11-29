using App.Core.Dtos;
using App.Core.Interface;
using Microsoft.AspNetCore.Mvc;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Extensions.Primitives;

namespace App.Core.Apps.User.Command
{
    public class AddRegisterCommand : IRequest<object>
    {
        public RegisterDto  registerDto { get; set; }
        public IFormFile File { get; set; }
        public string RequestHost { get; set; }
        public string RequestScheme { get; set; }
    }
    public class AddRegisterCommandHandler : IRequestHandler<AddRegisterCommand, object>
    {
        private readonly IAppDbContext _appDbContext;

        private readonly IEmailService _emailService;

        private readonly IFileService _fileservice;
        public AddRegisterCommandHandler(IAppDbContext appDbContext, IEmailService emailService, IFileService fileservice)
        {
            _appDbContext = appDbContext;
            _emailService = emailService;
            _fileservice = fileservice;
        }
        public async Task<object> Handle(AddRegisterCommand request, CancellationToken cancellationToken)
        {

            var imageFile = request.File;

            var allowedFileExtensions = new string[] { ".jpg", ".jpeg", ".png" };
            var filePath = await _fileservice.SaveFileAsync(imageFile, allowedFileExtensions);
            var fileUrl = $"{request.RequestScheme}://{request.RequestHost}/{filePath.Replace('\\', '/')}";

            var checkemail = await _appDbContext.Set<Domain.User>().Where(x=>x.Email==request.registerDto.Email).FirstOrDefaultAsync();

            if (checkemail != null)
            {
                return new { message = "Email already exist" };
            }

            // Generate Username
            string formattedDOB = request.registerDto.DOB.ToString("ddMMyy");
            string username = $"EC_{request.registerDto.LastName.ToUpper()}{request.registerDto.FirstName.ToUpper()[0]}{formattedDOB}";

            // Generate Password
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string password = new string(Enumerable.Repeat(chars, 8).Select(s => s[new Random().Next(s.Length)]).ToArray());

            // Encrypt Username and Password
            string encryptedUsername = Encrypt(username);
            //string encryptedPassword = Encrypt(password);
            var encryptedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            //var images =await _fileservice.SaveFileAsync(request.registerDto.ImageFile, allowedFileExtensions);
           
            // Create new user
            var user = new Domain.User
            {
                FirstName = request.registerDto.FirstName,
                LastName = request.registerDto.LastName,
                Email = request.registerDto.Email,
                RoleId = request.registerDto.RoleId,
                DOB = request.registerDto.DOB,
                Mobile = request.registerDto.Mobile,
                Address = request.registerDto.Address,
                Zipcode = request.registerDto.Zipcode,
                StateId = request.registerDto.StateId,
                CountryId = request.registerDto.CountryId,
                ImageFile = fileUrl,
                ProductImage = request.registerDto.ProductImage,
                Username = encryptedUsername,
                Password = encryptedPassword,
                IsActive = true,
                IsDeleted = false
            };

            await _appDbContext.Set<Domain.User>().AddAsync(user);
            await _appDbContext.SaveChangesAsync();
            await _emailService.SendEmailAsync(request.registerDto.Email, "Welcome to Our Application", $"Hello {request.registerDto.FirstName},\n\nYour account has been created successfully.\n\nUsername: {username}\nPassword: {password}\n\nRegards,\nTeam");
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
