using Application.CQRS.Items.Queries;
using Application.DTOs.Item;
using Application.Extensions;
using Core.Abstractions;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Items.Handlers;

public class ListItemsQueryHandler(IItemRepository repository) : IRequestHandler<ListItemsQuery, Result<List<ReadItemDto>>>
{
    public async Task<Result<List<ReadItemDto>>> Handle(ListItemsQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.GetAllFromCartAsync(request.CartId);
        var itemDtos = result.Value.Select(item => item.ToDto()).ToList();
        return Result.Success(itemDtos);
    }
}