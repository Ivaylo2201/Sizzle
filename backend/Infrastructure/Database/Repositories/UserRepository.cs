using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories;

public class UserRepository(DatabaseContext context) : IUserRepository
{
    public async Task<Result<User>> Create(User item)
    {
        item.Password = BCrypt.Net.BCrypt.HashPassword(item.Password);
        var result = context.Users.Add(item);
        await context.SaveChangesAsync();
        return Result.Success(result.Entity);
    }

    public async Task<Result<User?>> GetOne(int id)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        
        return user is null 
            ? Result.Failure<User?>("User not found")
            : Result.Success<User?>(user);
    }

    public async Task<Result> Update(User item)
    {
        item.Password = BCrypt.Net.BCrypt.HashPassword(item.Password);
        context.Users.Update(item);
        await context.SaveChangesAsync();
        return Result.Success();
    }
}