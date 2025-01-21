using App.Core.Dto;
using App.Core.Interface;
using AutoMapper;
using Doamin.ResponseModal;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PasswordGenerator;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.App.User.Command
{
    public class RegisterUserCommand : IRequest<JsonModal>
    {
        public registerDto registerDto { get; set; }
    }
    public class  RegisterUserCommandHandller : IRequestHandler<RegisterUserCommand, JsonModal>
    {
        private readonly IAppDbContext _appDbContext;
        private readonly ILogger _logger;
        private readonly IEmailService _emailService;
        private readonly IMapper  _mapper;

        public RegisterUserCommandHandller(IAppDbContext appDbContext, IMapper mapper,IEmailService emailService,ILogger<RegisterUserCommandHandller> logger)
        {
            _appDbContext = appDbContext;
_logger = logger;
            _emailService = emailService;
            _mapper = mapper;
        }

        public async Task<JsonModal> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            var checkemail = await _appDbContext.Set<Doamin.User>().Where(a=>a.Email==request.registerDto.Email)
                         .FirstOrDefaultAsync();


            if (checkemail !=null)
            {
                _logger.LogError("Error in the Register handller");
                return new JsonModal((int)HttpStatusCode.Conflict, "Email already exists", null);
            }
            string formattedDOB = request.registerDto.DateOfBirth.ToString("ddMMyy");
            string username = $"MV_{textInfo.ToTitleCase(request.registerDto.FirstName)}{request.registerDto.LastName.ToUpper()[0]}{formattedDOB}";

            var passwordGenerator = new Password(true, true, true, true, 13);
            string password = passwordGenerator.Next();
            password = password.Replace("\\", "");
            password = $"{password}#";
            var encryptedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            //var user = new Doamin.User
            //{
            //    FirstName = request.registerDto.FirstName,
            //    LastName = request.registerDto.LastName,
            //    Email = request.registerDto.Email,
            //    Password = encryptedPassword,
            //    UserName = username,
            //    DateOfBirth = request.registerDto.DateOfBirth,
            //    IsActive = true,
            //    IsDeleted = false,
            //    CreatedBy = request.registerDto.FirstName + request.registerDto.LastName,
            //    CreatedOn = DateTime.Now
            //};

            // automapper used here 
            var user = _mapper.Map<Doamin.User>(request.registerDto);
            user.UserName = username;
            user.Password = encryptedPassword;
            user.IsActive = true;
            user.IsDeleted = false;
            user.CreatedBy = request.registerDto.FirstName + request.registerDto.LastName;
            user.CreatedOn = DateTime.Now;
            await _appDbContext.Set<Doamin.User>().AddAsync(user);
            await _appDbContext.SaveChangesAsync();

            await _emailService.SendEmailAsync(request.registerDto.Email,
               "Welcome to Our Application", $"Hello {request.registerDto.FirstName}" +
               $",\n\nYour account has been created successfully.\n\nUsername: " +
               $"{username}\nPassword: {password}\n\nRegards,\nTeam");
            _logger.LogInformation("User created successfully");
            return new JsonModal((int)HttpStatusCode.Created, "User created successfully", user);
        }
    }
}
