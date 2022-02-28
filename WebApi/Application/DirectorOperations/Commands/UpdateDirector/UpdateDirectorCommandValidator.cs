using FluentValidation;

namespace WebApi.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommandValidator : AbstractValidator<UpdateDirectorCommand>
    {
        public UpdateDirectorCommandValidator()
        {
            RuleFor(x => x.DirectorId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Model.FirstName).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Model.LastName).NotEmpty().MinimumLength(3);
        }
    }
}
