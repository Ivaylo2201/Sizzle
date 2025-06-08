using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Generic;

namespace Core.Interfaces.Repositories;

public interface IItemRepository : 
    ICreatable<Item>, 
    IUpdatable<Item>, 
    IDeletable<int>, 
    IReadable<Item, int>
{
    Task<Result<List<Item>>> GetAllFromCartAsync(int cartId);
}