using Application.CQRS.Items.Queries;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Items.Handlers;

public class GetItemQueryHandler(IItemRepository itemRepository) : IRequestHandler<GetItemQuery, Result<Item?>>
{
    public async Task<Result<Item?>> Handle(GetItemQuery request, CancellationToken cancellationToken)
    {
        var result = await itemRepository.GetOne(request.Id);

        if (!result.IsSuccess || result.Value is null)
            return Result.Failure<Item?>(result.Error);
        
        return Result.Success<Item?>(result.Value);
    }
}