using Application.DTOs.City;
using Core.Entities;

namespace Application.Extensions;

public static class CityExtensions
{
    public static GetCityDto ToDto(this City city)
    {
        return new GetCityDto
        {
            Id = city.Id,
            CityName = city.CityName,
        };
    }
}