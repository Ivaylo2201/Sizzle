using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories;

public class ProductRepository(DatabaseContext context) : IProductRepository
{
    public async Task<Result<List<Product>>> GetAllProductsByCategory(string category)
    {
        var products = await context.Products
            .Include(p => p.Category)
            .Where(p => p.Category.CategoryName == category)
            .ToListAsync();
        
        return Result.Success(products);
    }

    public async Task<Result<Product?>> GetOne(Guid id)
    {
        var product = await context.Products
            .Include(p => p.Category)
            .Include(p => p.Reviews)
                .ThenInclude(r => r.User)
            .Include(p => p.Ingredients)
            .FirstOrDefaultAsync(p => p.Id == id);

        return product == null
            ? Result.Failure<Product?>($"Product {id} not found.") 
            : Result.Success<Product?>(product);
    }
}