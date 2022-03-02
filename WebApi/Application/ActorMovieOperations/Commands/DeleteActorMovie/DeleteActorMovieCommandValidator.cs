using FluentValidation;

namespace WebApi.Application.ActorMovieOperations.Commands.DeleteActorMovie
{
    public class DeleteActorMovieCommandValidator : AbstractValidator<DeleteActorMovieCommand>
    {
        public DeleteActorMovieCommandValidator()
        {
            RuleFor(x => x.ActorMovieId).NotEmpty().GreaterThan(0);
        }
    }
}
