using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Database.Entities;

[Table("Orders")]
public class Order
{
    [Key]
    public int Id { get; init; }

    public DateTime CreatedAt { get; init; } = DateTime.Now;
    
    [Required]
    public required int UserId { get; init; }
    public User User { get; init; } = null!;
    
    public ICollection<Item> Items { get; init; } = new List<Item>();
}