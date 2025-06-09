namespace Application.DTOs.User;

public record UpdateUserDto
{
    public required int Id { get; init; }
    public required string PhoneNumber { get; init; }
    public required string Password { get; init; }
}