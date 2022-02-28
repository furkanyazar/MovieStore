using System;
using FluentValidation;

namespace WebApi.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(x => x.Model.DirectorId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Model.GenreId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Model.Name).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Model.Price).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Model.YearOfConstruction).NotEmpty().LessThan(DateTime.Today.AddDays(1));
        }
    }
}
