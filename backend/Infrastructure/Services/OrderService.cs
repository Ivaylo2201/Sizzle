using Core.Entities;
using Core.Interfaces.Services;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class OrderService(DatabaseContext context) : IOrderService
{
    private async Task<List<Item>> GetItemsFromUsersCart(int userId)
    {
        var user = await context.Users.SingleOrDefaultAsync(user => user.Id == userId);

        if (user is null)
            return [];
        
        var items = await context.Items.Where(item => item.CartId == user.CartId).ToListAsync();
        return items;
    }
    
    public async Task MarkItemsInUsersCartAsOrderedAsync(int userId, Order order)
    {
        var items = await GetItemsFromUsersCart(userId);
        
        foreach (var item in items)
        {
            item.Cart = null;
            item.Order = order;
        }
        await context.SaveChangesAsync();
    }
}