using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories;

public class CityRepository(DatabaseContext context) : ICityRepository
{
    public async Task<Result<List<City>>> GetAllAsync()
    {
        var categories = await context.Cities.ToListAsync();
        return Result.Success(categories);
    }
}