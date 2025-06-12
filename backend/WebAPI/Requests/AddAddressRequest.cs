namespace WebAPI.Requests;

public record AddAddressRequest
{
    public int CityId { get; set; }
    public required string StreetName { get; set; }
    public required int StreetNumber { get; set; }
};