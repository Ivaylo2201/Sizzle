namespace Core.Entities;

public class Item
{
    public int Id { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public required int Quantity { get; set; }
    public int? CartId { get; set; }
    public Cart Cart { get; set; } = null!;
    public int? OrderId { get; set; }
    public Order Order { get; set; } = null!;
}