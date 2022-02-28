using FluentValidation;

namespace WebApi.Application.DirectorOperations.Queries.GetDirectorDetail
{
    public class GetDirectorDetailQueryValidator : AbstractValidator<GetDirectorDetailQuery>
    {
        public GetDirectorDetailQueryValidator()
        {
            RuleFor(x => x.DirectorId).NotEmpty().GreaterThan(0);
        }
    }
}
