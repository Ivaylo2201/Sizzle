using Application.CQRS.Carts.Queries;
using Application.DTOs.Cart;
using Application.Extensions;
using Core.Abstractions;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Carts.Handlers;

public class GetCartQueryHandler(ICartRepository cartRepository) :
    IRequestHandler<GetCartQuery, Result<GetCartDto?>>
{
    public async Task<Result<GetCartDto?>> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        var result = await cartRepository.GetOneByUserIdAsync(request.UserId);
        
        if (!result.IsSuccess || result.Value == null)
            return Result.Failure<GetCartDto?>(result.Error);

        var cartDto = result.Value.ToDto();
        return Result.Success<GetCartDto?>(cartDto);
    }
}