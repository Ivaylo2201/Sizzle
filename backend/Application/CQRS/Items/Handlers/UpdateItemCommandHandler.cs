using Application.CQRS.Items.Commands;
using Core.Abstractions;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Items.Handlers;

public class UpdateItemCommandHandler(IItemRepository itemRepository) : 
    IRequestHandler<UpdateItemCommand, Result>
{
    public async Task<Result> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        var result = await itemRepository.GetOne(request.Dto.Id);

        if (!result.IsSuccess || result.Value is null)
            return Result.Failure(result.Error);

        var item = result.Value!;
        item.Quantity = request.Dto.Quantity;
        return await itemRepository.Update(item);
    }
}