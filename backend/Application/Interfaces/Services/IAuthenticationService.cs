namespace Application.Interfaces.Services;

public interface IAuthenticationService
{
    Task<bool> IsSignedUp(string username, string password);
    Task<bool> IsUsernameTaken(string username);
}