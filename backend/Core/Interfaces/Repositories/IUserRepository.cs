using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Generic;

namespace Core.Interfaces.Repositories;

public interface IUserRepository :
    ICreatable<User>,
    ISingleReadable<User, int>,
    IUpdatable<User>
{
    Task<(bool, User?)> IsSignedUp(string username, string password);
    Task<bool> IsUsernameTaken(string username);
}