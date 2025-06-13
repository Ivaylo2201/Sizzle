using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories;

public class AddressRepository(DatabaseContext context) : IAddressRepository
{
    public async Task<Result<Address>> CreateAsync(Address item)
    {
        var result = await context.Addresses.AddAsync(item);
        await context.SaveChangesAsync();
        return Result.Success(result.Entity);
    }

    public async Task<Result> UpdateAsync(Address address)
    {
        context.Addresses.Update(address);
        await context.SaveChangesAsync();
        return Result.Success();
    }

    public async Task<Result> DeleteAsync(int id)
    {
        var address = await context.Addresses.SingleOrDefaultAsync(a => a.Id == id);

        if (address is null)
            return Result.Failure($"Address {id} not found.");

        context.Addresses.Remove(address);
        await context.SaveChangesAsync();
        return Result.Success();
    }

    public async Task<Result<List<Address>>> GetAllAddressesForUserAsync(int userId)
    {
        var addresses = await context.Addresses
            .Include(a => a.City)
            .Where(a => a.UserId == userId)
            .ToListAsync();

        return Result.Success(addresses);
    }

    public async Task<Result<Address>> GetOneAsync(int id)
    {
        var address = await context.Addresses.SingleOrDefaultAsync(a => a.Id == id);

        return address == null
            ? Result.Failure<Address>($"Address {id} not found.")
            : Result.Success(address);
    }
}