using Application.CQRS.Items.Commands;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Items.Handlers;

public class CreateItemCommandHandler(IItemRepository itemRepository, IProductRepository productRepository, ICartRepository cartRepository) : 
    IRequestHandler<CreateItemCommand, Result<Item>>
{
    public async Task<Result<Item>> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        var productResult = await productRepository.GetOne(request.Dto.ProductId);
        
        if (!productResult.IsSuccess || productResult.Value is null)
            return Result.Failure<Item>($"Product with id {request.Dto.ProductId} not found.");
        
        await cartRepository.UpdateCartTotal(request.Dto.CartId, request.Dto.Quantity * productResult.Value.Price);
        
        var item = new Item
        {
            ProductId = request.Dto.ProductId,
            Quantity = request.Dto.Quantity,
            CartId = request.Dto.CartId
        };

        return await itemRepository.Create(item);
    }
}