using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Database.Entities;


[Table("Ingredients")]
public class Ingredient
{
    [Key]
    public int Id { get; init; }
    
    [Required]
    [MaxLength(50)]
    public required string IngredientName { get; init; }
    
    public ICollection<Product> Products { get; init; } = new List<Product>();
}