namespace Application.DTOs.Address;

public record UpdateAddressDto
{
    public required Core.Entities.Address Address { get; init; }
    public required Core.Entities.City City { get; init; }
    public required string StreetName { get; init; }
    public required int StreetNumber { get; init; }
}