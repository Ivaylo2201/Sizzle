using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories;

public class UserRepository(DatabaseContext context) : IUserRepository
{
    public async Task<Result<User>> Create(User user)
    {
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        
        var result = context.Users.Add(user);
        var cart = new Cart { User = user };
        context.Carts.Add(cart);
        
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

    public async Task<Result> Update(User user)
    {
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        context.Users.Update(user);
        await context.SaveChangesAsync();
        return Result.Success();
    }
}