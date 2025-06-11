namespace Application.Interfaces.Services;

public interface IOwnershipService
{
    Task<bool> HasItemOwnership(int itemId, int userId);
}