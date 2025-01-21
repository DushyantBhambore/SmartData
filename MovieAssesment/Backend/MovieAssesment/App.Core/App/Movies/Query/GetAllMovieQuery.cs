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

namespace App.Core.App.Movies.Query
{
    public class GetAllMovieQuery : IRequest<JsonModal>
    {
    }
    public class GetAllMovieQueryHandller : IRequestHandler<GetAllMovieQuery , JsonModal>
    {
        private readonly IAppDbContext _appDbContext;
        private readonly ILogger<GetAllMovieQueryHandller> _logger;

        public GetAllMovieQueryHandller(IAppDbContext appDbContext, ILogger<GetAllMovieQueryHandller> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task<JsonModal> Handle(GetAllMovieQuery request, CancellationToken cancellationToken)
        {
            var result = await _appDbContext.Set<Doamin.MovieDetails>().ToListAsync();
            if  (result.Count ==0)
            {
                _logger.LogError("No Data Found ");
                return new JsonModal((int)HttpStatusCode.BadRequest, "No Data Found", null);
            }

            _logger.LogInformation("Get All MOvie Details ");
            return new JsonModal((int)HttpStatusCode.OK, "Success", result);
        }
    }
}
