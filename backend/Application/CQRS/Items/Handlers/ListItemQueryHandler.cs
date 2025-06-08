using Application.CQRS.Items.Queries;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Items.Handlers;

public class ListItemQueryHandler(IItemRepository repository) : IRequestHandler<ListItemQuery, Result<List<Item>>>
{
    public async Task<Result<List<Item>>> Handle(ListItemQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetAllFromCartAsync(request.CartId);
    }
}