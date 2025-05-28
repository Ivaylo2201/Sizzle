using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs.User;

public class LoginUserDto
{
    [MaxLength(50)]
    [EmailAddress]
    public required string Email { get; set; }
    
    public required string Password { get; set; }
}