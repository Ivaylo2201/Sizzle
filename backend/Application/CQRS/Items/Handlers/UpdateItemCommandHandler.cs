using Application.CQRS.Items.Commands;
using Core.Abstractions;
using Core.Interfaces;
using MediatR;

namespace Application.CQRS.Items.Handlers;

public class UpdateItemCommandHandler(IItemRepository repository) : IRequestHandler<UpdateItemCommand, Result>
{
    public async Task<Result> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        var result = await repository.GetOne(request.ItemId);

        if (!result.IsSuccess)
            return Result.Failure(result.Error);

        var item = result.Value;
        item.Quantity = request.Quantity;
        return await repository.Update(item);
    }
}