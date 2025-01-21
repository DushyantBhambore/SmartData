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
using System.Threading.Tasks;

namespace App.Core.App.Movies.Command
{
    public class AddMovieCommand : IRequest<JsonModal>
    {
        public MovieDetailsDto  MovieDetailsDto { get; set; }
    }
    public class AddMovieCommandHandller : IRequestHandler<AddMovieCommand, JsonModal>
    {
        private readonly IAppDbContext _appDbContext;
        private readonly IEmailService _emailService;
        private readonly IFileService _fileService;
        private readonly ILogger<AddMovieCommandHandller> _logger;
        private readonly IMapper _mapper;

        public AddMovieCommandHandller
            (ILogger<AddMovieCommandHandller> logger,IAppDbContext appDbContext
            ,IEmailService emailService, IMapper _mappe, IFileService fileService)
        {
            _logger = logger;
            _appDbContext = appDbContext;
            _emailService = emailService;
            _fileService = fileService;
            _mapper = _mappe;
        }

        public async Task<JsonModal> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {

            var checkmoview = await _appDbContext.Set<Doamin.MovieDetails>()
                .Where(a => a.MoviTitle == request.MovieDetailsDto.MoviTitle).FirstOrDefaultAsync();


            if (checkmoview != null)
            {
                _logger.LogError("Movie Already Exists");
                return new JsonModal((int)HttpStatusCode.BadRequest, "Movie Already Exists",null);
            }
            var imageFile = request.MovieDetailsDto.Posterimage;

            var allowedFileExtensions = new string[] { ".jpg", ".jpeg", ".png" };
            var filePath = await _fileService.SaveFileAsync(imageFile, allowedFileExtensions);
            var fileUrl = $"https://localhost:7206/Uploads/{Path.GetFileName(filePath)}";

            //var addmovie = new Doamin.MovieDetails()
            //{
            //    MoviTitle = request.MovieDetailsDto.MoviTitle,
            //    Posterimage = fileUrl,
            //    ReleaseDate = request.MovieDetailsDto.ReleaseDate,
            //    UserId =  request.MovieDetailsDto.UserId,
            //    IsActive = true,
            //    IsDeleted = false,
            //};

            var addmovie = _mapper.Map<Doamin.MovieDetails>(request.MovieDetailsDto);
            addmovie.Posterimage = fileUrl;

            addmovie.IsActive = true;
            addmovie.IsDeleted = false;
            await _appDbContext.Set<Doamin.MovieDetails>().AddAsync(addmovie);
            await _appDbContext.SaveChangesAsync();
            _logger.LogInformation("Movie Added Successfully");
            return new JsonModal((int)HttpStatusCode.OK, "Movie Added Successfully",null);

        }
    }
}
