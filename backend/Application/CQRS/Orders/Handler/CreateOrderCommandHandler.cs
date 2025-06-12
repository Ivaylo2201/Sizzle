using Application.CQRS.Orders.Commands;
using Application.Interfaces.Services;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Orders.Handler;

public class CreateOrderCommandHandler(
    IOrderRepository orderRepository, 
    IUserRepository userRepository, 
    IOrderService orderService) : IRequestHandler<CreateOrderCommand, Result<Order>>
{
    public async Task<Result<Order>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetOne(request.Dto.UserId);

        if (!user.IsSuccess || user.Value is null)
            return Result.Failure<Order>(user.Error);
        
        var order = new Order { User = user.Value };
        var result = await orderRepository.Create(order);
        
        await orderService.MarkItemsInUsersCartAsOrderedAsync(request.Dto.UserId, order);
        
        return Result.Success(result.Value);
    }
}