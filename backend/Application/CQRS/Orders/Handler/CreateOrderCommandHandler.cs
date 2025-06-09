using Application.CQRS.Orders.Commands;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using MediatR;

namespace Application.CQRS.Orders.Handler;

public class CreateOrderCommandHandler(
    IOrderRepository orderRepository, 
    IUserRepository userRepository, 
    IOrderService orderService) : IRequestHandler<CreateOrderCommand, Result<Order>>
{
    public async Task<Result<Order>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var userResult = await userRepository.GetOne(request.Dto.UserId);

        if (!userResult.IsSuccess || userResult.Value is null)
            return Result.Failure<Order>(userResult.Error);
        
        var order = new Order { User = userResult.Value };
        var result = await orderRepository.Create(order);
        
        await orderService.MarkItemsInUsersCartAsOrderedAsync(request.Dto.UserId, order);
        
        return Result.Success(result.Value);
    }
}