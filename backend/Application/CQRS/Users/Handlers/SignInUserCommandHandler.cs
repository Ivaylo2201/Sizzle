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
        var result = await userRepository.GetOneByUsernameAndPassword(request.Dto.Username, request.Dto.Password);

        if (!result.IsSuccess || result.Value is null)
            return Result.Failure<User?>(result.Error);
        
        return Result.Success<User?>(result.Value);
    }
}