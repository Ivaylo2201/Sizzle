using Application.CQRS.Items.Commands;
using FluentValidation;

namespace Application.CQRS.Items.Validators;

public class UpdateItemCommandValidator : AbstractValidator<UpdateItemCommand>
{
    public UpdateItemCommandValidator()
    {
        RuleFor(c => c.Dto.ItemId)
            .NotEmpty().WithMessage("ItemId must be provided.")
            .GreaterThan(0).WithMessage("ItemId must be greater than 0.");
        
        RuleFor(c => c.Dto.Quantity)
            .NotEmpty().WithMessage("Quantity must be provided.")
            .InclusiveBetween(1, 20).WithMessage("Quantity must be between 1 and 20.");
    }
}