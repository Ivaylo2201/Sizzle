using Application.CQRS.Users.Commands;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Users.Handlers;

public class SignInUserCommandHandler(IUserRepository userRepository) : IRequestHandler<SignInUserCommand, Result<User?>>
{
    public async Task<Result<User?>> Handle(SignInUserCommand request, CancellationToken cancellationToken)
    {
        var (isSignedUp, user) = await userRepository.IsSignedUp(request.Dto.Username, request.Dto.Password);
        
        return isSignedUp
            ? Result.Success(user)
            : Result.Failure<User?>("Invalid credentials provided.");
    }
}