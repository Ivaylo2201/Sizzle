using Application.CQRS.Items.Queries;
using Application.DTOs.Item;
using Application.Extensions;
using Core.Abstractions;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Items.Handlers;

public class GetItemQueryHandler(IItemRepository itemRepository) : IRequestHandler<GetItemQuery, Result<GetItemDto?>>
{
    public async Task<Result<GetItemDto?>> Handle(GetItemQuery request, CancellationToken cancellationToken)
    {
        var result = await itemRepository.GetOne(request.Id);

        if (!result.IsSuccess || result.Value is null)
            return Result.Failure<GetItemDto?>(result.Error);
        
        var itemDto = result.Value.ToDto();
        return Result.Success<GetItemDto?>(itemDto);
    }
}