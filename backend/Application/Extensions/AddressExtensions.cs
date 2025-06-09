using Application.DTOs.Address;
using Core.Entities;

namespace Application.Extensions;

public static class AddressExtensions
{
    public static ReadAddressDto ToDto(this Address address)
    {
        return new ReadAddressDto
        {
            Id = address.Id,
            StreetName = address.StreetName,
            StreetNumber = address.StreetNumber,
            CityName = address.City.CityName,
        };
    }
}