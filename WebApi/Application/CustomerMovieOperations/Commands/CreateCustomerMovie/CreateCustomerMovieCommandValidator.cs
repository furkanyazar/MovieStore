using FluentValidation;

namespace WebApi.Application.CustomerMovieOperations.Commands.CreateCustomerMovie
{
    public class CreateCustomerMovieCommandValidator : AbstractValidator<CreateCustomerMovieCommand>
    {
        public CreateCustomerMovieCommandValidator()
        {
            RuleFor(x => x.Model.CustomerId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Model.MovieId).NotEmpty().GreaterThan(0);
        }
    }
}
