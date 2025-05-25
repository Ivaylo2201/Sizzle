using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Database.Entities;

[Table("Carts")]
public class Cart
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public required int UserId { get; set; }
    public User User { get; set; } = null!;
    
    [Column(TypeName = "decimal(10,2)")]
    public decimal Total { get; set; }
    
    public ICollection<Item> Items { get; set; } = new List<Item>();
}