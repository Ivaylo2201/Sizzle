using Backend.DTOs.Product;

namespace Backend.Repositories.Interfaces;

public interface IProductRepository
{
    Task<List<ProductShortDto>> GetAllProductsAsync();
    Task<ProductLongDto?> GetProductByIdAsync(int id);
}