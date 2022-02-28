using FluentValidation;

namespace WebApi.Application.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>
    {
        public CreateDirectorCommandValidator()
        {
            RuleFor(x => x.Model.FirstName).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Model.LastName).NotEmpty().MinimumLength(3);
        }
    }
}
