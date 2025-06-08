using Application.CQRS.Orders.Queries;
using Application.DTOs.Order;
using Application.Extensions;
using Core.Abstractions;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Orders.Handler;

public class ListOrdersQueryHandler(IOrderRepository repository) : IRequestHandler<ListOrdersQuery, Result<List<ReadOrderDto>>>
{
    public async Task<Result<List<ReadOrderDto>>> Handle(ListOrdersQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.GetAllOrdersForUser(request.UserId);
        var orderDtos = result.Value.Select(order => order.ToDto()).ToList();
        return Result.Success(orderDtos);
    }
}