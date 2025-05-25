using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Database.Entities;


[Table("Products")]
public class Product
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(30)]
    public required string ProductName { get; set; }
    
    [Required]
    [Range(1, 1000)]
    [Column(TypeName = "decimal(10,2)")]
    public required decimal Price { get; set; }
    
    [DefaultValue(0)]
    [Range(0, 100)]
    public int? DiscountPercentage { get; set; } = 0;
    
    [Required]
    [MaxLength(255)]
    [Url]
    public required string ImageUrl { get; set; }
    
    [Required]
    [MaxLength(100)]
    public required string Description { get; set; }
    
    [Required]
    [Range(1, 5000)]
    public required int Calories { get; set; }
    
    [Required]
    public required int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}