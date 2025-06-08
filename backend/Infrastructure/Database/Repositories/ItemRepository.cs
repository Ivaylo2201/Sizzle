using Core.Abstractions;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories;

public class ItemRepository(DatabaseContext context) : IItemRepository
{
    public async Task<Result<Item>> Create(Item item)
    {
        var result = await context.Items.AddAsync(item);
        await context.SaveChangesAsync();
        return Result<Item>.Success(result.Entity);
    }

    public async Task<Result<List<Item>>> GetAll()
    {
        var items = await context.Items.ToListAsync();
        return Result<List<Item>>.Success(items);
    }

    public async Task<Result<Item>> GetOne(int id)
    {
        var item = await context.Items.FirstOrDefaultAsync(x => x.Id == id);
        
        return item == null
            ? Result<Item>.Failure($"Item {id} not found.") 
            : Result<Item>.Success(item);
    }

    public async Task<Result> Update(Item item)
    {
        context.Items.Update(item);
        var isSuccess = await context.SaveChangesAsync() > 0;
        
        return isSuccess
            ? Result.Success()
            : Result.Failure("Failed to update item.");
    }

    public async Task<Result> Delete(int id)
    {
        var result = await GetOne(id);
        
        if (!result.IsSuccess)
            return Result.Failure($"Item {id} not found.");
        
        context.Items.Remove(result.Value);
        await context.SaveChangesAsync();
        return Result.Success();
    }
}