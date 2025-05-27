using Backend.Database;
using Backend.DTOs.Product;
using Backend.Mappers;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class ProductRepository(DatabaseContext context) : IProductRepository
{
    public async Task<List<ProductShortDto>> GetAllProductsAsync()
    {
        var products = await  context.Products.Select(p => p.ToShortDto()).ToListAsync();
        return products;
    }

    public async Task<ProductLongDto?> GetProductByIdAsync(int id)
    {
        var product = await context.Products.Include(p => p.Category)
                                            .Include(p => p.Ingredients)
                                            .Include(p => p.Reviews)
                                                .ThenInclude(r => r.User)
                                            .AsSplitQuery()
                                            .FirstOrDefaultAsync(p => p.Id == id);
        
        return product?.ToLongDto();
    }
}