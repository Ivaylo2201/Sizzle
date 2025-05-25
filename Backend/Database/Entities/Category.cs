using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Database.Entities;


[Table("Categories")]
public class Category
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(20)]
    public required string CategoryName { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}