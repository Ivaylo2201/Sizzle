using Application.CQRS.Orders.Commands;
using Application.Interfaces.Services;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Orders.Handlers;

public class CreateOrderCommandHandler(
    IOrderRepository orderRepository,
    IAddressRepository addressRepository,
    IOrderService orderService) : IRequestHandler<CreateOrderCommand, Result<Order>>
{
    public async Task<Result<Order>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            User = request.Dto.User, 
            Address = request.Dto.Address,
            Notes = request.Dto.Notes,
            DeliveryTime = request.Dto.DeliveryTime
        };
        
        var orderResult = await orderRepository.CreateAsync(order);

        var addressResult = await addressRepository.GetOneAsync(request.Dto.Address.Id);
        
        if (addressResult.Value.UserId != request.Dto.User.Id)
            return Result.Failure<Order>(addressResult.Error);
        
        var markResult = await orderService.MarkItemsInUsersCartAsOrderedAsync(request.Dto.User.Id, order);

        return markResult.IsSuccess
            ? Result.Success(orderResult.Value)
            : Result.Failure<Order>(markResult.Error);
    }
}