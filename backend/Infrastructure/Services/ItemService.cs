using Core.Entities;
using Core.Interfaces.Services;
using Infrastructure.Database;

namespace Infrastructure.Services;

public class ItemService(DatabaseContext context) : IItemService
{
    public async Task MarkAsOrdered(List<Item> items, Order order)
    {
        foreach (var item in items)
        {
            item.Cart = null;
            item.Order = order;
        }
        
        await context.SaveChangesAsync();
    }
}