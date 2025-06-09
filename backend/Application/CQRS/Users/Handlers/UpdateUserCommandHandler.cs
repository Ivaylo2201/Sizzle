using Application.CQRS.Users.Commands;
using Core.Abstractions;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Users.Handlers;

public class UpdateUserCommandHandler(IUserRepository repository) : 
    IRequestHandler<UpdateUserCommand, Result>
{
    public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var result = await repository.GetOne(request.Dto.Id);

        if (!result.IsSuccess || result.Value == null)
            return Result.Failure(result.Error);

        var user = result.Value;
        user.PhoneNumber = request.Dto.PhoneNumber;
        user.Password = request.Dto.Password;
        return await repository.Update(user);
    }
}