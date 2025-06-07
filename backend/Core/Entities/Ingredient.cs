namespace Core.Entities;

public class Ingredient
{
    public int Id { get; set; }
    public required string IngredientName { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();
}