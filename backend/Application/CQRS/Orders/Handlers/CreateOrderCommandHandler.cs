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
    IUserRepository userRepository,
    IOrderService orderService) : IRequestHandler<CreateOrderCommand, Result<Order>>
{
    public async Task<Result<Order>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var userResult = await userRepository.GetOneAsync(request.Dto.UserId);
        
        if (!userResult.IsSuccess)
            return Result.Failure<Order>(userResult.Error);
        
        var addressResult = await addressRepository.GetOneAsync(request.Dto.AddressId);
        
        if (addressResult.Value.UserId != userResult.Value.Id)
            return Result.Failure<Order>(addressResult.Error);
        
        var order = new Order
        {
            User = userResult.Value, 
            Address = addressResult.Value,
            Notes = request.Dto.Notes,
            DeliveryTime = request.Dto.DeliveryTime
        };
        
        var orderResult = await orderRepository.CreateAsync(order);
        
        var markResult = await orderService.MarkItemsInUsersCartAsOrderedAsync(userResult.Value.Id, order);

        return markResult.IsSuccess
            ? Result.Success(orderResult.Value)
            : Result.Failure<Order>(markResult.Error);
    }
}