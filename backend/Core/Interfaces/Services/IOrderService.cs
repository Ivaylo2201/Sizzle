using Core.Abstractions;
using Core.Entities;

namespace Core.Interfaces.Services;

public interface IOrderService
{
    Task<Result> MarkItemsInUsersCartAsOrderedAsync(int userId, Order order);
}