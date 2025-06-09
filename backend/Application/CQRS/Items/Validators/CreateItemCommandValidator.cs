using Application.CQRS.Items.Commands;
using FluentValidation;

namespace Application.CQRS.Items.Validators;

public class CreateItemCommandValidator : AbstractValidator<CreateItemCommand>
{
    public CreateItemCommandValidator()
    {
        RuleFor(c => c.Dto.ProductId)
            .NotEqual(Guid.Empty).WithMessage("ProductId must be provided.");
        
        RuleFor(c => c.Dto.CartId)
            .NotEmpty().WithMessage("CartId must be provided.")
            .GreaterThan(0).WithMessage("CartId must be greater than 0.");
    }
}