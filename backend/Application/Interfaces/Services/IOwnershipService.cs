namespace Application.Interfaces.Services;

public interface IOwnershipService
{
    Task<bool> HasItemOwnership(int? cartId, int userId);
    Task<bool> HasAddressOwnership(int addressId, int userId);
}