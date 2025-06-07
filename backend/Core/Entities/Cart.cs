namespace Core.Entities;

public class Cart
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public double Total { get; set; } = 0;
    public ICollection<Item> Items { get; set; } = new List<Item>();
}