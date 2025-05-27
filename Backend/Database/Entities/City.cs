using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Database.Entities;

[Table("Cities")]
public class City
{
    [Key]
    public int Id { get; init; }
    
    [Required]
    [MaxLength(25)]
    public required string CityName { get; init; }
    
    public ICollection<Address> Addresses { get; init; } = new List<Address>();
}