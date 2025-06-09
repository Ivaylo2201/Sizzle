using Application.CQRS.Orders.Commands;
using FluentValidation;

namespace Application.CQRS.Orders.Validators;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(c => c.Dto.UserId)
            .NotEmpty().WithMessage("UserId must be provided.")
            .GreaterThan(0).WithMessage("UserId must be greater than 0.");
    }
}