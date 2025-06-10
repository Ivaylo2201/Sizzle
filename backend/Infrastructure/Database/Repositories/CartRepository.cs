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

    public async Task<Result<Cart?>> GetOneByUserIdAsync(int userId)
    {
        var cart = await context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
        
        return cart == null
            ? Result.Failure<Cart?>($"User {userId}'s cart not found.") 
            : Result.Success<Cart?>(cart);
    }
    
    public async Task<Result<List<Item>?>> GetItemsFromUsersCart(int userId)
    {
        var user = await context.Users.SingleOrDefaultAsync(u => u.Id == userId);

        if (user is null)
            return Result.Failure<List<Item>?>($"Multiple users or no user with id {userId} found.");
        
        var items = await context.Items.Where(i => i.CartId == user.Cart.Id).ToListAsync();
        return Result.Success<List<Item>?>(items);
    }

    public async Task<Result> UpdateCartTotal(int cartId, double amount)
    {
        var cart = await context.Carts.SingleOrDefaultAsync(c => c.Id == cartId);
        
        if (cart is null)
            return Result.Failure<List<Item>?>($"Multiple carts or no cart with id {cartId} found.");
        
        cart.Total += amount;
        await context.SaveChangesAsync();
        return Result.Success();
    }
}