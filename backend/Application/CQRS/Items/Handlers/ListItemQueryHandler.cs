using Application.CQRS.Items.Queries;
using Application.DTOs.Item;
using Application.Extension;
using Core.Abstractions;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Items.Handlers;

public class ListItemQueryHandler(IItemRepository repository) : IRequestHandler<ListItemQuery, Result<List<ItemDto>>>
{
    public async Task<Result<List<ItemDto>>> Handle(ListItemQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.GetAllFromCartAsync(request.CartId);
        return Result.Success(result.Value.Select(item => item.ToDto()).ToList());
    }
}