namespace Core.Entities;

public class Ingredient
{
    public int Id { get; init; }
    public required string IngredientName { get; init; }
    public ICollection<Product> Products { get; init; } = new List<Product>();
}