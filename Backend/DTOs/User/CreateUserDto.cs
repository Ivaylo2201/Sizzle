using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs.User;

public class CreateUserDto
{
    [Required]
    [MaxLength(20)]
    public required string FirstName { get; set; }
    
    [Required]
    [MaxLength(20)]
    public required string LastName { get; set; }
    
    public required string Password { get; set; }
    
    [Compare("Password",  ErrorMessage = "Passwords do not match.")]
    public required string ConfirmPassword { get; set; }
    
    [MaxLength(50)]
    public string? Email { get; set; }
}