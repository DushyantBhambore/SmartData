using App.Core.App.Movies.Command;
using App.Core.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddMovies")]
        
        public async Task<IActionResult> AddMovies([FromBody] MovieDetailsDto movieDetailsDto)
        {
            var result = await _mediator.Send(new AddMovieCommand{ MovieDetailsDto = movieDetailsDto });
            return Ok(result);
        }

        [HttpDelete("DeleteMovies/{id}")]
        public async Task<IActionResult> DeleteMovies(int id)
        {
            var result = await _mediator.Send(new DeleteMovieCommand { id =id });
            return Ok(result);
        }

        [HttpPut("UpdateMovies")]
        public async Task<IActionResult> UpdateMovies([FromBody] MovieDetailsDto movieDetailsDto)
        {
            var result = await _mediator.Send(new UpdateMovieCommand { MovieDetailsDto = movieDetailsDto });
            return Ok(result);
        }
    }
}
