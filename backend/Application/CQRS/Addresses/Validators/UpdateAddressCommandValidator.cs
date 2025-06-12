using Application.CQRS.Addresses.Commands;
using FluentValidation;

namespace Application.CQRS.Addresses.Validators;

public class UpdateAddressCommandValidator : AbstractValidator<UpdateAddressCommand>
{
    public UpdateAddressCommandValidator()
    {
        RuleFor(c => c.Dto.City)
            .NotEmpty().WithMessage("City must be provided.");
        
        RuleFor(c => c.Dto.StreetName)
            .NotEmpty().WithMessage("StreetName must be provided.")
            .Length(3, 25).WithMessage("StreetName must be between 3 and 25 characters.");
        
        RuleFor(c => c.Dto.StreetNumber)
            .NotEmpty().WithMessage("StreetNumber must be provided.")
            .InclusiveBetween(0, 500).WithMessage("StreetNumber must be between 0 and 500.");
    }
}