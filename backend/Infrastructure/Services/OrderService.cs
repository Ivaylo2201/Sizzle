using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Infrastructure.Database;

namespace Infrastructure.Services;

public class OrderService(DatabaseContext context, ICartRepository cartRepository) : IOrderService
{
    public async Task<Result> MarkItemsInUsersCartAsOrderedAsync(int userId, Order order)
    {
        var result = await cartRepository.GetItemsFromUsersCart(userId);
        
        if (!result.IsSuccess || result.Value is null)
            return Result.Failure(result.Error);
        
        foreach (var item in result.Value)
        {
            item.Cart = null;
            item.Order = order;
        }
        
        var isDone = await context.SaveChangesAsync() == result.Value.Count;
        return Result.Success(isDone);
    }
}