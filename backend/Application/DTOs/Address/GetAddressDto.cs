namespace Application.DTOs.Address;

public record GetAddressDto
{
    public required int Id { get; init; }
    public required string CityName { get; init; }
    public required string StreetName { get; init; }
    public required int StreetNumber { get; init; }
}