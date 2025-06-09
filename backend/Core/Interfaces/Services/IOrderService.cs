using Core.Entities;

namespace Core.Interfaces.Services;

public interface IOrderService
{
    Task MarkItemsInUsersCartAsOrderedAsync(int userId, Order order);
}