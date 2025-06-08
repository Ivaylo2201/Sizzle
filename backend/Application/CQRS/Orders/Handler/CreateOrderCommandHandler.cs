using Application.CQRS.Orders.Commands;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using MediatR;

namespace Application.CQRS.Orders.Handler;

public class CreateOrderCommandHandler(IOrderRepository repository, IItemService service) : IRequestHandler<CreateOrderCommand, Result<Order>>
{
    public async Task<Result<Order>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order { User = request.Dto.User };
        var result = await repository.Create(order);
        await service.MarkAsOrdered(request.Dto.User.Cart.Items.ToList(), order);
        return Result.Success(result.Value);
    }
}