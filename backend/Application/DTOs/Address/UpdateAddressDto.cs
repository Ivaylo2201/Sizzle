namespace Application.DTOs.Address;

public record UpdateAddressDto
{
    public required int Id { get; init; }
    public required int CityId { get; init; }
    public required string StreetName { get; init; }
    public required int StreetNumber { get; init; }
}