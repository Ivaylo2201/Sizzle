using System.ComponentModel.DataAnnotations;

namespace Backend.Database.Entities;

public class User
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(20)]
    public required string FirstName { get; set; }
    
    [Required]
    [MaxLength(20)]
    public required string LastName { get; set; }
    
    [MaxLength(50)]
    public string? Email { get; set; }
    
    [Required]
    [MaxLength(64)]
    public required string Password { get; set; }

    public Cart Cart { get; set; } = null!;
    
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<Address> Addresses { get; set; } = new List<Address>();
}