using System.ComponentModel.DataAnnotations;

namespace Backend.Database.Entities;

public class User
{
    [Key]
    public int Id { get; init; }
    
    [Required]
    [MaxLength(50)]
    public required string Name { get; init; }
    
    [Required]
    [MaxLength(50)]
    [EmailAddress]
    public required string Email { get; set; }
    
    [Required]
    [MaxLength(64)]
    public required string Password { get; set; }

    public Cart Cart { get; init; } = null!;
    
    public ICollection<Review> Reviews { get; init; } = new List<Review>();
    public ICollection<Order> Orders { get; init; } = new List<Order>();
    public ICollection<Address> Addresses { get; init; } = new List<Address>();
}