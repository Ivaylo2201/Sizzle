using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Generic;

namespace Core.Interfaces.Repositories;

public interface IOrderRepository : ICreatable<Order>
{
    Task<Result<List<Order>>> GetAllOrdersForUser(int userId);
}