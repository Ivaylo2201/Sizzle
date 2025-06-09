using Application.CQRS.Items.Queries;
using Application.DTOs.Item;
using Application.Extensions;
using Core.Abstractions;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Items.Handlers;

public class ListItemsQueryHandler(IItemRepository itemRepository, ICartRepository cartRepository) :
    IRequestHandler<ListItemsQuery, Result<List<ReadItemDto>?>>
{
    public async Task<Result<List<ReadItemDto>?>> Handle(ListItemsQuery request, CancellationToken cancellationToken)
    {
        var cartResult = await cartRepository.GetOne(request.CartId);

        if (!cartResult.IsSuccess)
            return Result.Failure<List<ReadItemDto>?>(cartResult.Error);

        var itemResult = await itemRepository.GetAllFromCartAsync(request.CartId);
        var itemDtos = itemResult.Value.Select(item => item.ToDto()).ToList();
        return Result.Success<List<ReadItemDto>?>(itemDtos);
    }
}