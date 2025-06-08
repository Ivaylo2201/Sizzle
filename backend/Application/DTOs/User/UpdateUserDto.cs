namespace Application.DTOs.User;

public record UpdateUserDto
{
    public required int UserId { get; init; }
    public required string PhoneNumber { get; init; }
    public required string Password { get; init; }
}