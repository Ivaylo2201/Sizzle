using Application.Interfaces.Services;
using Core.Entities;
using Core.Interfaces.Repositories;

namespace Infrastructure.Services;

public class AuthenticationService(IUserRepository userRepository) : IAuthenticationService
{
    public async Task<(bool, User)> IsSignedUp(string username, string password)
    {
        var userResult = await userRepository.GetOne(username);

        if (!userResult.IsSuccess || !BCrypt.Net.BCrypt.Verify(password, userResult.Value.Password))
            return (false, userResult.Value);

        return (true, userResult.Value);
    }
    
    public async Task<bool> IsUsernameTaken(string username)
    {
        var userResult = await userRepository.GetOne(username);
        return userResult.IsSuccess;
    }
}