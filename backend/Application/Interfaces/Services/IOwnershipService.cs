namespace Application.Interfaces.Services;

public interface IOwnershipService
{
    Task<bool> HasItemOwnershipAsync(int? cartId, int userId);
    Task<bool> HasAddressOwnershipAsync(int addressId, int userId);
}