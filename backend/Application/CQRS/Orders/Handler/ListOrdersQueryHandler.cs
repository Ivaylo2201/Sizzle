using Application.CQRS.Orders.Queries;
using Application.DTOs.Order;
using Application.Extensions;
using Core.Abstractions;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Orders.Handler;

public class ListOrdersQueryHandler(IOrderRepository orderRepository, IUserRepository userRepository) : 
    IRequestHandler<ListOrdersQuery, Result<List<GetOrderDto>?>>
{
    public async Task<Result<List<GetOrderDto>?>> Handle(ListOrdersQuery request, CancellationToken cancellationToken)
    {
        var userResult = await userRepository.GetOne(request.UserId);
        
        if (!userResult.IsSuccess || userResult.Value == null)
            return Result.Failure<List<GetOrderDto>?>(userResult.Error);
        
        var result = await orderRepository.GetAllOrdersForUser(request.UserId);
        var orderDtos = result.Value.Select(order => order.ToDto()).ToList();
        return Result.Success<List<GetOrderDto>?>(orderDtos);
    }
}