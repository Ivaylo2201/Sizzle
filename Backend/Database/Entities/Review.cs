using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Database.Entities;

[Table("Reviews")]
public class Review
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [Range(1, 5)]
    public required int Rating { get; set; }
    
    [MaxLength(150)]
    public string? Comment { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    [Required]
    public required int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    
    [Required]
    public required int UserId  { get; set; }
    public User User { get; set; } = null!;
}