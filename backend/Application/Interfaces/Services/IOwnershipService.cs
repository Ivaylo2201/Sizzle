namespace Application.Interfaces.Services;

public interface IOwnershipService
{
    Task<bool> HasItemOwnership(int itemId, int userId);
    Task<bool> HasAddressOwnership(int addressId, int userId);
}