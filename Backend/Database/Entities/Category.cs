using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Database.Entities;


[Table("Categories")]
public class Category
{
    [Key]
    public int Id { get; init; }
    
    [Required]
    [MaxLength(20)]
    public required string CategoryName { get; init; }

    public ICollection<Product> Products { get; init; } = new List<Product>();
}