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
    
    public string? Email { get; set; }
    
    [Required]
    [MaxLength(64)]
    public required string Password { get; set; }
    
    public ICollection<Address> Addresses { get; set; } = new List<Address>();
}