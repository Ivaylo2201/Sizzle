using Application.CQRS.Users.Commands;
using FluentValidation;

namespace Application.CQRS.Users.Validators;

public class SignInUserCommandValidator : AbstractValidator<SignInUserCommand>
{
    public SignInUserCommandValidator()
    {
        RuleFor(c => c.Dto.Username)
            .NotEmpty().WithMessage("Username must be provided.")
            .Length(5, 25).WithMessage("Username must be between 5 and 25 characters.");

        RuleFor(c => c.Dto.Password)
            .NotEmpty().WithMessage("Password must be provided.")
            .MinimumLength(5).WithMessage("Password must be at least 5 characters long.");
    }
}