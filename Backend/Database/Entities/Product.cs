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
    public required decimal InitialPrice { get; set; }
    
    [NotMapped]
    public decimal Price => InitialPrice * (1 - DiscountPercentage / 100m);
    
    [DefaultValue(0)]
    [Range(0, 100)]
    public int DiscountPercentage { get; set; }
    
    [Required]
    [MaxLength(255)]
    [Url]
    public required string ImageUrl { get; set; }
    
    [Required]
    [MaxLength(255)]
    public required string Description { get; set; }
    
    [Required]
    [Range(1, 5000)]
    public required int Calories { get; set; }
    
    [Required]
    public required int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    
    // Change back init to set if needed!!!
    public ICollection<Item> Items { get; init; } = new List<Item>();
    public ICollection<Review> Reviews { get; init; } = new List<Review>();
    public ICollection<Ingredient> Ingredients { get; init; } = new List<Ingredient>();
}