namespace Core.Entities;

public class User
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Password { get; set; }
    public Cart Cart { get; set; } = null!;
    public ICollection<Address> Addresses { get; set; } = new List<Address>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}