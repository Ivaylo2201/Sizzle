using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Database.Entities;


[Table("Ingredients")]
public class Ingredient
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(20)]
    public required string IngredientName { get; set; }
    
    public ICollection<Product> Products { get; set; } = new List<Product>();
}