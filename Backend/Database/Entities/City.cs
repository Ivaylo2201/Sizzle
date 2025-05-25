using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Database.Entities;

[Table("Cities")]
public class City
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(25)]
    public required string CityName { get; set; }
    
    public ICollection<Address> Addresses { get; set; } = new List<Address>();
}