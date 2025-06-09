using Application.DTOs.Product;
using Core.Entities;

namespace Application.Extensions;

public static class ProductExtensions
{
    // TODO: Make sure you prefetch Reviews, Ingredients and Category
    
    public static GetProductLongDto ToLongDto(this Product product)
    {
        return new GetProductLongDto
        {
            Id = product.Id,
            ProductName = product.ProductName,
            InitialPrice = product.InitialPrice,
            DiscountPercentage = product.DiscountPercentage,
            ImageUrl = product.ImageUrl,
            Description = product.Description,
            Calories = product.Calories,
            Weight = product.Weight,
            CategoryName = product.Category.CategoryName,
            Reviews = product.Reviews.Select(r => r.ToDto()).ToList(),
            Ingredients = product.Ingredients.Select(i => i.IngredientName).ToList(),
            Price = product.Price,
        };

    }
    
    public static GetProductShortDto ToShortDto(this Product product)
    {
        return new GetProductShortDto
        {
            Id = product.Id,
            ProductName = product.ProductName,
            InitialPrice = product.InitialPrice,
            DiscountPercentage = product.DiscountPercentage,
            Price = product.Price,
            ImageUrl = product.ImageUrl,
            Description = product.Description,
        };

    }
}