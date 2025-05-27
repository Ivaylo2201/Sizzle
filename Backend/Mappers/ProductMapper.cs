using Backend.Database.Entities;
using Backend.DTOs.Product;

namespace Backend.Mappers;

public static class ProductMapper
{
    public static ProductShortDto ToShortDto(this Product product)
    {
        return new ProductShortDto
        {
            Id = product.Id,
            ProductName = product.ProductName,
            InitialPrice = product.InitialPrice,
            Price = product.Price,
            DiscountPercentage = product.DiscountPercentage,
            ImageUrl = product.ImageUrl
        };
    }

    public static ProductLongDto ToLongDto(this Product product)
    {
        return new ProductLongDto
        {
            Id = product.Id,
            ProductName = product.ProductName,
            InitialPrice = product.InitialPrice,
            Price = product.Price,
            DiscountPercentage = product.DiscountPercentage,
            ImageUrl = product.ImageUrl,
            Description = product.Description,
            Calories = product.Calories,
            Category = product.Category.CategoryName,
            Reviews = product.Reviews.Select(r => r.ToDto()).ToList(),
            Ingredients = product.Ingredients.Select(i => i.IngredientName).ToList()
        };
    }
}