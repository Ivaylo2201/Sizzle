using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Database.Entities;

[Table("Addresses")]
public class Address
{
    [Key]
    public int Id { get; init; }
    
    [Required]
    [MaxLength(20)]
    public required string StreetName { get; init; }
    
    [Required]
    [Range(1, 1000)]
    public int StreetNumber { get; init; }
    
    [Required]
    public required int CityId { get; init; }
    public City City { get; init; } = null!;
    
    [Required]
    public required int UserId { get; init; }
    public User User { get; init; } = null!;
}