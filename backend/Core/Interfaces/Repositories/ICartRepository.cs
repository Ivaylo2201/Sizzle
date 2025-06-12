using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Generic;

namespace Core.Interfaces.Repositories;

public interface ICartRepository :
    ICreatable<Cart>,
    IUpdatable<Cart>
{
    Task<Result<Cart?>> GetOneByUserIdAsync(int userId);
    Task<Result<List<Item>?>> GetItemsFromUsersCart(int userId);
}