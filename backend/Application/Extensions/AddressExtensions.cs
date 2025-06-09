using Application.DTOs.Address;
using Core.Entities;

namespace Application.Extensions;

public static class AddressExtensions
{
    public static GetAddressDto ToDto(this Address address)
    {
        return new GetAddressDto
        {
            Id = address.Id,
            StreetName = address.StreetName,
            StreetNumber = address.StreetNumber,
            CityName = address.City.CityName,
        };
    }
}