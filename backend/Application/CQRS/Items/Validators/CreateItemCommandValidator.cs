using Application.CQRS.Items.Commands;
using FluentValidation;

namespace Application.CQRS.Items.Validators;

public class CreateItemCommandValidator : AbstractValidator<CreateItemCommand>
{
    public CreateItemCommandValidator()
    {
        RuleFor(c => c.ProductId)
            .NotEqual(Guid.Empty).WithMessage("ProductId must be provided.");
        
        RuleFor(c => c.Quantity)
            .NotEmpty().WithMessage("Quantity must be provided.")
            .InclusiveBetween(1, 20).WithMessage("Quantity must be between 1 and 20.");
        
        RuleFor(c => c.CartId)
            .NotEmpty().WithMessage("CartId must be provided.")
            .GreaterThan(0).WithMessage("CartId must be greater than 0.");
    }
}