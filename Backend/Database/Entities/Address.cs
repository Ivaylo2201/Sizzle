using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Database.Entities;

[Table("Addresses")]
public class Address
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(20)]
    public required string StreetName { get; set; }
    
    [Required]
    [Range(1, 1000)]
    public int StreetNumber { get; set; }
    
    [Required]
    public required int CityId { get; set; }
    public City City { get; set; } = null!;
    
    [Required]
    public required int UserId { get; set; }
    public User User { get; set; } = null!;
}