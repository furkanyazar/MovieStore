using FluentValidation;

namespace WebApi.Application.CustomerGenreOperations.Commands.CreateCustomerGenre
{
    public class CreateCustomerGenreCommandValidator : AbstractValidator<CreateCustomerGenreCommand>
    {
        public CreateCustomerGenreCommandValidator()
        {
            RuleFor(x => x.Model.CustomerId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Model.GenreId).NotEmpty().GreaterThan(0);
        }
    }
}
