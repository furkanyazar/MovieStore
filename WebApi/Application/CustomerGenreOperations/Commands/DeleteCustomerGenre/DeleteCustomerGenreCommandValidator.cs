using FluentValidation;

namespace WebApi.Application.CustomerGenreOperations.Commands.DeleteCustomerGenre
{
    public class DeleteCustomerGenreCommandValidator : AbstractValidator<DeleteCustomerGenreCommand>
    {
        public DeleteCustomerGenreCommandValidator()
        {
            RuleFor(x => x.CustomerGenreId).NotEmpty().GreaterThan(0);
        }
    }
}
