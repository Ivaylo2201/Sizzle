using Application.Interfaces.Services;
using Core.Interfaces.Repositories;

namespace Infrastructure.Services;

public class OwnershipService(ICartRepository cartRepository) : IOwnershipService
{
    public async Task<bool> HasItemOwnership(int itemId, int userId)
    {
        var cartResult = await cartRepository.GetOneByUserIdAsync(userId);
        return itemId == cartResult.Value!.Id;
    }
}