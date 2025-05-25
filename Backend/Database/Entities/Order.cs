using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Database.Entities;

[Table("Orders")]
public class Order
{
    [Key]
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    [Required]
    public required int UserId { get; set; }
    public User User { get; set; } = null!;
    
    public ICollection<Item> Items { get; set; } = new List<Item>();
}