using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Database.Entities;

[Table("Carts")]
public class Cart
{
    [Key]
    public int Id { get; init; }
    
    [Required]
    public required int UserId { get; init; }
    public User User { get; init; } = null!;
    
    [Column(TypeName = "decimal(10,2)")]
    public decimal Total { get; set; }
    
    public ICollection<Item> Items { get; init; } = new List<Item>();
}