using FluentValidation;

namespace WebApi.Application.ActorOperations.Queries.GetActorDetail
{
    public class GetActorDetailQueryValidator : AbstractValidator<GetActorDetailQuery>
    {
        public GetActorDetailQueryValidator()
        {
            RuleFor(x => x.ActorId).NotEmpty().GreaterThan(0);
        }
    }
}
