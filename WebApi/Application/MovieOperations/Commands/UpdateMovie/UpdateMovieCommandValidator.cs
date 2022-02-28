using FluentValidation;

namespace WebApi.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidator()
        {
            RuleFor(x => x.Model.DirectorId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Model.GenreId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Model.Name).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Model.Price).NotEmpty().GreaterThan(0);
        }
    }
}
