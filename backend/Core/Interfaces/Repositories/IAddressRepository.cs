using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Generic;

namespace Core.Interfaces.Repositories;

public interface IAddressRepository :
    ICreatable<Address>,
    ISingleReadable<Address, int>,
    IUpdatable<Address>,
    IDeletable<int>
{
    Task<Result<List<Address>>> GetRecentAddressesForUserAsync(int userId);
}