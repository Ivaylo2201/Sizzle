using Core.Entities;

namespace Core.Interfaces.Services;

public interface IItemService
{
    Task MarkAsOrdered(List<Item> items, Order order);
}