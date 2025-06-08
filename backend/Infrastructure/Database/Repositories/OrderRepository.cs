using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories;

public class OrderRepository(DatabaseContext context) : IOrderRepository
{
    public async Task<Result<List<Order>>> GetAllOrdersForUser(int userId)
    {
        var itemsForUser = await context.Orders.Where(o => o.UserId == userId).ToListAsync();
        return Result.Success(itemsForUser);
    }

    public async Task<Result<Order>> Create(Order order)
    {
        var result = await context.Orders.AddAsync(order);
        await context.SaveChangesAsync();
        return Result.Success(result.Entity);
    }
}