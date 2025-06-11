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
        
        var result = await context.Users.AddAsync(user);
        var cart = new Cart { User = user };
        await context.Carts.AddAsync(cart);
        
        await context.SaveChangesAsync();
        return Result.Success(result.Entity);
    }
    
    public async Task<Result> Update(User user)
    {
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        context.Users.Update(user);
        await context.SaveChangesAsync();
        return Result.Success();
    }

    public async Task<Result<User?>> GetOne(int id)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        
        return user is null 
            ? Result.Failure<User?>("User not found")
            : Result.Success<User?>(user);
    }

    public async Task<(bool, User?)> IsSignedUp(string username, string password)
    {
        var user = await context.Users.SingleOrDefaultAsync(u => u.Username == username);
        
        if (user is null)
            return (false, null);
        
        var isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.Password);
        return isPasswordValid ? (true, user) : (false, null);
    }
    
    public async Task<bool> IsUsernameTaken(string username)
    {
        return await context.Users.AnyAsync(u => u.Username == username);
    }
}