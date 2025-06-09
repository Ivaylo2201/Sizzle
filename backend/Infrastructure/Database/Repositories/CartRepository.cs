using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories;

public class CartRepository(DatabaseContext context) : ICartRepository
{
    public async Task<Result<Cart>> Create(Cart item)
    {
        var result = await context.Carts.AddAsync(item);
        await context.SaveChangesAsync();
        return Result.Success(result.Entity);
    }

    public async Task<Result<Cart?>> GetOne(int id)
    {
        var cart = await context.Carts.FirstOrDefaultAsync(c => c.Id == id);
        
        return cart == null
            ? Result.Failure<Cart?>($"Cart {id} not found.") 
            : Result.Success<Cart?>(cart);
    }
}