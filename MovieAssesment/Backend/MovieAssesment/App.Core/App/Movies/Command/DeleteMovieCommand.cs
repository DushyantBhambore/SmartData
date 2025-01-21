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
    public class DeleteMovieCommand : IRequest<JsonModal>
    {
        public int id { get; set; }
    }
    public class DeleteMovieCommandHandller : IRequestHandler<DeleteMovieCommand, JsonModal>
    {
        private readonly IAppDbContext _appDbContext;
        private readonly ILogger<DeleteMovieCommandHandller> _logger;
        public DeleteMovieCommandHandller(IAppDbContext appDbContext, ILogger<DeleteMovieCommandHandller> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task<JsonModal> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {

            var checkid = await _appDbContext.Set<Doamin.MovieDetails>()
                .Where(a => a.MovieId == request.id).FirstOrDefaultAsync();

            if  (checkid ==null)
            {
                _logger.LogError("Movie is  Not Exits");
                return new JsonModal((int)HttpStatusCode.NotFound, "Movie is  Not Exits", null);
            }

            checkid.IsDeleted = true;
            checkid.IsActive = false;
            _logger.LogInformation("Movie Deleted Successfully");
            return new JsonModal((int)HttpStatusCode.OK, "Movie Deleted Successfully", null);

        }
    }
}
