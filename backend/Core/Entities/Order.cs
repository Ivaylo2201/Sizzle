namespace Core.Entities;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public ICollection<Item> Items { get; set; } = new List<Item>();
}