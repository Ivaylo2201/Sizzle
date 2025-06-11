using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories;

public class ItemRepository(DatabaseContext context) : IItemRepository
{
    public async Task<Result<Item>> Create(Item item)
    {
        var result = await context.Items.AddAsync(item);
        await context.SaveChangesAsync();
        return Result.Success(result.Entity);
    }

    public async Task<Result<Item?>> GetOne(int id)
    {
        var item = await context.Items.FirstOrDefaultAsync(i => i.Id == id);
        
        return item == null
            ? Result.Failure<Item?>($"Item {id} not found.") 
            : Result.Success<Item?>(item);
    }

    public async Task<Result> Update(Item item)
    {
        context.Items.Update(item);
        await context.SaveChangesAsync();
        return Result.Success();
    }

    public async Task<Result> Delete(int id)
    {
        var result = await GetOne(id);
        
        if (!result.IsSuccess || result.Value is null)
            return Result.Failure($"Item {id} not found.");
        
        context.Items.Remove(result.Value);
        await context.SaveChangesAsync();
        return Result.Success();
    }
}