using FluentValidation;

namespace WebApi.Application.DirectorMovieOperations.Commands.DeleteDirectorMovie
{
    public class DeleteDirectorMovieCommandValidator : AbstractValidator<DeleteDirectorMovieCommand>
    {
        public DeleteDirectorMovieCommandValidator()
        {
            RuleFor(x => x.DirectorMovieId).NotEmpty().GreaterThan(0);
        }
    }
}
