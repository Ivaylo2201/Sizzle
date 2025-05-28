using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs.User;

public class CreateUserDto
{
    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }
    
    [MaxLength(50)]
    [EmailAddress]
    public required string Email { get; set; }
    
    public required string Password { get; set; }
    
    [Compare("Password",  ErrorMessage = "Passwords do not match.")]
    public required string ConfirmPassword { get; set; }
}