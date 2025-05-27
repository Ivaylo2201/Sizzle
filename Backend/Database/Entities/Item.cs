using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Database.Entities;

[Table("Items")]
public class Item
{
    public int Id { get; init; }
    
    [Required]
    [Range(1, 10)]
    public required int Quantity { get; set; }
    
    [Required]
    public required int ProductId { get; init; }
    public Product Product { get; init; } = null!;
    
    public int? CartId { get; set; }
    public Cart? Cart { get; set; }
    
    public int? OrderId { get; set; }
    public Order? Order { get; set; }
}