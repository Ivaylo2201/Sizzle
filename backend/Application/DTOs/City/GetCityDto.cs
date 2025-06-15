namespace Application.DTOs.City;

public record GetCityDto
{
    public required int Id { get; init; }
    public required string CityName { get; init; }
};