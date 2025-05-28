using Backend.Database.Entities;
using Backend.DTOs.User;

namespace Backend.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserByEmail(string email);
    Task<User?> GetUserById(int id);
    Task<User> CreateUser(CreateUserDto dto);
}