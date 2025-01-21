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

namespace App.Core.App.Movies.Command
{
    public class UpdateMovieCommand : IRequest<JsonModal>
    {
        public MovieDetailsDto MovieDetailsDto { get; set; }
    }
    public class UpdateMovieCommandHandller : IRequestHandler<UpdateMovieCommand, JsonModal>
    {
        private readonly IAppDbContext _appDbContext;
        private readonly IFileService  _fileService;
        private readonly ILogger<UpdateMovieCommandHandller> _logger;
        public UpdateMovieCommandHandller(IAppDbContext appDbContext, IFileService fileService, ILogger<UpdateMovieCommandHandller> logger)
        {
            _appDbContext = appDbContext;
            _fileService = fileService;
            _logger = logger;
        }

        public async Task<JsonModal> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {

            var checkmovie = await _appDbContext.Set<Doamin.MovieDetails>().
                Where(a => a.MovieId == request.MovieDetailsDto.MovieId).FirstOrDefaultAsync();

            if ( checkmovie == null)
            {
                _logger .LogError("Movie Not Found");
                return  new JsonModal((int) HttpStatusCode.NotFound, "Movie Not Found", null);
            }

            var imageFile = request.MovieDetailsDto.Posterimage;

            if (imageFile != null)
            {
                var allowedFileExtensions = new string[] { ".jpg", ".jpeg", ".png" };
                var filePath = await _fileService.SaveFileAsync(imageFile, allowedFileExtensions);
                var fileUrl = $"https://localhost:7161/Uploads/{Path.GetFileName(filePath)}";
                checkmovie.Posterimage = fileUrl;
            }

            checkmovie.MoviTitle = request.MovieDetailsDto.MoviTitle;
            checkmovie.ReleaseDate= request.MovieDetailsDto.ReleaseDate;

            _logger.LogInformation("Movie Updated Successfully");
            return new JsonModal((int)HttpStatusCode.OK, "Movie Updated Successfully", null);
    
        }
    }
}
