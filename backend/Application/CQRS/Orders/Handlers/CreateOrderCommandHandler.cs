using Application.CQRS.Orders.Commands;
using Application.Interfaces.Services;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Orders.Handlers;

public class CreateOrderCommandHandler(
    IOrderRepository orderRepository, 
    IOrderService orderService) : IRequestHandler<CreateOrderCommand, Result<Order>>
{
    public async Task<Result<Order>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order { User = request.Dto.User };
        var result = await orderRepository.CreateAsync(order);
        
        var markResult = await orderService.MarkItemsInUsersCartAsOrderedAsync(request.Dto.User.Id, order);

        return markResult.IsSuccess
            ? Result.Success(result.Value)
            : Result.Failure<Order>(markResult.Error);
    }
}