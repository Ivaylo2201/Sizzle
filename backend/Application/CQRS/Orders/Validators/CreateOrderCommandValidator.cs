using Application.CQRS.Orders.Commands;
using FluentValidation;

namespace Application.CQRS.Orders.Validators;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(c => c.Dto.User)
            .NotEmpty().WithMessage("User must be provided.");
    }
}