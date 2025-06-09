using Application.CQRS.Items.Queries;
using Application.DTOs.Item;
using Application.Extensions;
using Core.Abstractions;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Items.Handlers;

public class ListItemsQueryHandler(IItemRepository itemRepository, ICartRepository cartRepository) :
    IRequestHandler<ListItemsQuery, Result<List<GetItemDto>?>>
{
    public async Task<Result<List<GetItemDto>?>> Handle(ListItemsQuery request, CancellationToken cancellationToken)
    {
        var cartResult = await cartRepository.GetOne(request.CartId);

        if (!cartResult.IsSuccess || cartResult.Value is null)
            return Result.Failure<List<GetItemDto>?>(cartResult.Error);

        var itemResult = await itemRepository.GetAllFromCartAsync(request.CartId);
        var itemDtos = itemResult.Value.Select(i => i.ToDto()).ToList();
        return Result.Success<List<GetItemDto>?>(itemDtos);
    }
}