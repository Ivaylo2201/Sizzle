using Application.CQRS.Users.Commands;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Users.Handlers;

public class CreateUserCommandHandler(IUserRepository repository) : IRequestHandler<CreateUserCommand, Result<User>>
{
    public async Task<Result<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Username = request.Dto.Username,
            PhoneNumber = request.Dto.PhoneNumber,
            Password = request.Dto.Password,
        };
        
        return await repository.Create(user);
    }
}