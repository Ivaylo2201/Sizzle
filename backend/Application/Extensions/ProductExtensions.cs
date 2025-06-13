using Application.DTOs.Product;
using Core.Entities;

namespace Application.Extensions;

public static class ProductExtensions
{
    public static GetProductLongDto ToLongDto(this Product product)
    {
        return new GetProductLongDto
        {
            Id = product.Id,
            ProductName = product.ProductName,
            InitialPrice = product.InitialPrice,
            DiscountPercentage = product.DiscountPercentage,
            Rating = CalculateRating(product.Reviews),
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
            Rating = CalculateRating(product.Reviews),
            Price = product.Price,
            ImageUrl = product.ImageUrl,
            Description = product.Description,
        };
    }

    private static int CalculateRating(ICollection<Review> reviews)
    {
        if (reviews.Count == 0)
            return 0;

        return (int)Math.Floor(reviews.Average(r => r.Rating));
    }
}