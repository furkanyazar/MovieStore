using FluentValidation;

namespace WebApi.Application.DirectorMovieOperations.Commands.CreateDirectorMovie
{
    public class CreateDirectorMovieCommandValidator : AbstractValidator<CreateDirectorMovieCommand>
    {
        public CreateDirectorMovieCommandValidator()
        {
            RuleFor(x => x.Model.DirectorId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Model.MovieId).NotEmpty().GreaterThan(0);
        }
    }
}
