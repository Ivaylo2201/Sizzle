using Core.Entities;

namespace Application.Interfaces.Services;

public interface IAuthenticationService
{
    Task<(bool, User)> IsSignedUp(string username, string password);
    Task<bool> IsUsernameTaken(string username);
}