using System;
using FluentValidation;

namespace WebApi.Application.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.Model.CustomerId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Model.DateOfOrder).NotEmpty().GreaterThan(DateTime.Today);
            RuleFor(x => x.Model.MovieId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Model.Price).NotEmpty().GreaterThan(0);
        }
    }
}
