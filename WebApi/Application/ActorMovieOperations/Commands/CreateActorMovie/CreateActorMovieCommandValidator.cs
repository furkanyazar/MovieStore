using FluentValidation;

namespace WebApi.Application.ActorMovieOperations.Commands.CreateActorMovie
{
    public class CreateActorMovieCommandValidator : AbstractValidator<CreateActorMovieCommand>
    {
        public CreateActorMovieCommandValidator()
        {
            RuleFor(x => x.Model.ActorId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Model.MovieId).NotEmpty().GreaterThan(0);
        }
    }
}
