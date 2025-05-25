using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Database.Entities;

[Table("Items")]
public class Item
{
    public int Id { get; set; }
    
    [Required]
    [Range(1, 10)]
    public required int Quantity { get; set; }
    
    [Required]
    public required int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    
    public int? CartId { get; set; }
    public Cart? Cart { get; set; }
    
    public int? OrderId { get; set; }
    public Order? Order { get; set; }
}