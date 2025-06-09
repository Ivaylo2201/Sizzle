using Application.CQRS.Users.Commands;
using Core.Abstractions;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Users.Handlers;

public class UpdateUserCommandHandler(IUserRepository userRepository) : 
    IRequestHandler<UpdateUserCommand, Result>
{
    public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var result = await userRepository.GetOne(request.Dto.Id);

        if (!result.IsSuccess || result.Value is null)
            return Result.Failure(result.Error);

        var user = result.Value;
        user.PhoneNumber = request.Dto.PhoneNumber;
        user.Password = request.Dto.Password;
        return await userRepository.Update(user);
    }
}