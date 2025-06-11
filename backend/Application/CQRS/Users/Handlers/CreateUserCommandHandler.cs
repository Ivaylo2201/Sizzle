using Application.CQRS.Users.Commands;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Users.Handlers;

public class CreateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, Result<User?>>
{
    public async Task<Result<User?>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var isUsernameTaken = await userRepository.IsUsernameTaken(request.Dto.Username);
        
        if (isUsernameTaken)
            return Result.Failure<User?>("Username already taken.");
        
        var user = new User
        {
            Username = request.Dto.Username,
            PhoneNumber = request.Dto.PhoneNumber,
            Password = request.Dto.Password,
        };
        
        var result = await userRepository.Create(user);
        return Result.Success<User?>(result.Value); 
    }
}