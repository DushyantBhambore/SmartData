using Doamin;
using FluentValidation;

namespace API.FluentValidation
{
    public class MovieDetailsValidators : AbstractValidator<MovieDetails>
    {
        public MovieDetailsValidators()
        {
            RuleFor(a => a.MoviTitle).NotEmpty().WithMessage("MoviTitle is required");

            RuleFor(movie => movie.ReleaseDate).InclusiveBetween(1000, 9999)
                .WithMessage("Release date must be a valid year with 4 digits.")
                .NotEmpty().WithMessage("Release date is required.");
            RuleFor(movie => movie.Posterimage).NotEmpty().WithMessage("Poster image is required.");
        }
    }
}
