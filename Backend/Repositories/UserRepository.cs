using Backend.Database;
using Backend.Database.Entities;
using Backend.DTOs.User;
using Backend.Mappers;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class UserRepository(DatabaseContext context) : IUserRepository
{
    public async Task<User?> GetUserByEmail(string email)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User?> GetUserById(int id)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User> CreateUser(CreateUserDto dto)
    {
        var result = await context.Users.AddAsync(dto.ToUser());
        await context.SaveChangesAsync();
        return result.Entity;
    }
}