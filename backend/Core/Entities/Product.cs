namespace Core.Entities;

public class Product
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string ProductName { get; set; }
    public required double Price { get; set; }
    public int DiscountPercentage { get; set; }
    public required string ImageUrl { get; set; }
    public required string Description { get; set; }
    public required int Calories { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public ICollection<Item> Items { get; set; } = new List<Item>();
}