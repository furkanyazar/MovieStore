using System;
using FluentValidation;

namespace WebApi.Application.OrderOperations.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(x => x.OrderId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Model.Price).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Model.DateOfOrder).NotEmpty().GreaterThan(DateTime.Today);
        }
    }
}
