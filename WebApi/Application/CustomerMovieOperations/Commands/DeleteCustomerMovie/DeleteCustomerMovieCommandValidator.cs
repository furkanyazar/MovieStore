using FluentValidation;

namespace WebApi.Application.CustomerMovieOperations.Commands.DeleteCustomerMovie
{
    public class DeleteCustomerMovieCommandValidator : AbstractValidator<DeleteCustomerMovieCommand>
    {
        public DeleteCustomerMovieCommandValidator()
        {
            RuleFor(x => x.CustomerMovieId).NotEmpty().GreaterThan(0);
        }
    }
}
