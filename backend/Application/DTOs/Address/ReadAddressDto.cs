namespace Application.DTOs.Address;

public record ReadAddressDto
{
    public required int Id { get; init; }
    public required string CityName { get; init; }
    public required string StreetName { get; set; }
    public required int StreetNumber { get; set; }
}