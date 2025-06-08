using Application.CQRS.Items.Commands;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Items.Handlers;

public class CreateItemCommandHandler(IItemRepository repository) : IRequestHandler<CreateItemCommand, Result<Item>>
{
    public async Task<Result<Item>> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        var item = new Item
        {
            ProductId = request.ProductId,
            Quantity = request.Quantity,
            CartId = request.CartId
        };

        return await repository.Create(item);
    }
}