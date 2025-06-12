using Application.Interfaces.Services;
using Core.Interfaces.Repositories;

namespace Infrastructure.Services;

public class AuthenticationService(IUserRepository userRepository) : IAuthenticationService
{
    public async Task<bool> IsSignedUp(string username, string password)
    {
        var userResult = await userRepository.GetOne(username);

        return userResult.IsSuccess && BCrypt.Net.BCrypt.Verify(password, userResult.Value.Password);
    }
    
    public async Task<bool> IsUsernameTaken(string username)
    {
        var userResult = await userRepository.GetOne(username);
        return userResult.IsSuccess;
    }
}