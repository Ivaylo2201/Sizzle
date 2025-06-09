using Application.CQRS.Addresses.Commands;
using FluentValidation;

namespace Application.CQRS.Addresses.Validators;

public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
{
    public CreateAddressCommandValidator()
    {
        RuleFor(c => c.Dto.CityId)
            .NotEmpty().WithMessage("CityId must be provided.")
            .GreaterThan(0).WithMessage("CityId must be greater than 0.");
        
        RuleFor(c => c.Dto.UserId)
            .NotEmpty().WithMessage("UserId must be provided.")
            .GreaterThan(0).WithMessage("UserId must be greater than 0.");
        
        RuleFor(c => c.Dto.StreetName)
            .NotEmpty().WithMessage("StreetName must be provided.")
            .Length(3, 25).WithMessage("StreetName must be between 3 and 25 characters.");
        
        RuleFor(c => c.Dto.StreetNumber)
            .NotEmpty().WithMessage("StreetNumber must be provided.")
            .InclusiveBetween(0, 500).WithMessage("StreetNumber must be between 0 and 500.");
    }
}