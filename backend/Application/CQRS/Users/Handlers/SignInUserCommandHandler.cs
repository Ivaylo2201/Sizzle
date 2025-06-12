using Application.CQRS.Users.Commands;
using Application.Interfaces.Services;
using Core.Abstractions;
using MediatR;

namespace Application.CQRS.Users.Handlers;

public class SignInUserCommandHandler(IAuthenticationService authenticationService) :
    IRequestHandler<SignInUserCommand, Result>
{
    public async Task<Result> Handle(SignInUserCommand request, CancellationToken cancellationToken)
    {
        if (!await authenticationService.IsSignedUp(request.Dto.Username, request.Dto.Password))
            return Result.Failure("Invalid credentials provided.");

        return Result.Success();
    }
}