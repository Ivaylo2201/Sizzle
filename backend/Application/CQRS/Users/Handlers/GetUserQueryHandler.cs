using Application.CQRS.Users.Queries;
using Application.DTOs.User;
using Application.Extensions;
using Core.Abstractions;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Users.Handlers;

public class GetUserQueryHandler(IUserRepository repository) : IRequestHandler<GetUserQuery, Result<ReadUserDto?>>
{
    public async Task<Result<ReadUserDto?>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.GetOne(request.UserId);
        
        if (!result.IsSuccess)
            return Result.Failure<ReadUserDto?>(result.Error);
        
        var dto = result.Value!.ToDto();
        return Result.Success<ReadUserDto?>(dto);
    }
}