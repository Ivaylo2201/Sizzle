using Application.Interfaces.Services;
using Core.Interfaces.Repositories;

namespace Infrastructure.Services;

public class OwnershipService(ICartRepository cartRepository, IAddressRepository addressRepository) : IOwnershipService
{
    public async Task<bool> HasItemOwnershipAsync(int? cartId, int userId)
    {
        var cart = await cartRepository.GetOneByUserIdAsync(userId);
        return cartId == cart.Value.Id;
    }

    public async Task<bool> HasAddressOwnershipAsync(int addressId, int userId)
    {
        var addressResult = await addressRepository.GetOneAsync(addressId);
        return addressResult.Value.UserId == userId;
    }
}