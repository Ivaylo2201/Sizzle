using Backend.DTOs.Product;

namespace Backend.Repositories.Interfaces;

public interface IProductRepository
{
    Task<List<ProductShortDto>> GetProductsByCategory(string category);
    Task<ProductLongDto?> GetProductByIdAsync(int id);
}