using System.ComponentModel.DataAnnotations;

namespace Backend.Database.Entities;

public class Ingredient
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(20)]
    public required string IngredientName { get; set; }
    
    public ICollection<Product> Products { get; set; } = new List<Product>();
}