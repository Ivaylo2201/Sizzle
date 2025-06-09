namespace Application.DTOs.Address;

public record CreateAddressDto
{
    public required int CityId { get; init; }
    public required string StreetName { get; init; }
    public required int StreetNumber { get; init; }
    public required int UserId { get; init; }
}