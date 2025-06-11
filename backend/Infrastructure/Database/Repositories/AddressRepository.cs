using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories;

public class AddressRepository(DatabaseContext context) : IAddressRepository
{
    public async Task<Result<Address>> Create(Address item)
    {
        var result = await context.Addresses.AddAsync(item);
        await context.SaveChangesAsync();
        return Result.Success(result.Entity);
    }

    public async Task<Result> Update(Address address)
    {
        context.Addresses.Update(address);
        await context.SaveChangesAsync();
        return Result.Success();
    }

    public async Task<Result> Delete(int id)
    {
        var result = await GetOne(id);
        
        if (!result.IsSuccess || result.Value is null)
            return Result.Failure($"Address {id} not found.");
        
        context.Addresses.Remove(result.Value);
        await context.SaveChangesAsync();
        return Result.Success();
    }

    public async Task<Result<Address?>> GetOne(int id)
    {
        var address = await context.Addresses.SingleOrDefaultAsync(a => a.Id == id);
        
        return address == null
            ? Result.Failure<Address?>($"Address {id} not found.") 
            : Result.Success<Address?>(address);
    }
}