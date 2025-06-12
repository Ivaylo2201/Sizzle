using Application.CQRS.Addresses.Commands;
using FluentValidation;

namespace Application.CQRS.Addresses.Validators;

public class DeleteAddressCommandValidator : AbstractValidator<DeleteAddressCommand>
{
    public DeleteAddressCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty().WithMessage("Id must be provided.")
            .GreaterThan(0).WithMessage("Id must be greater than 0.");
    }
}