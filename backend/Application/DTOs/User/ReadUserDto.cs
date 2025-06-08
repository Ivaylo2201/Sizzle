using Application.DTOs.Review;

namespace Application.DTOs.User;

public record ReadUserDto
{
    // TODO: Implement
    public required string Username { get; init; }
    public required string PhoneNumber { get; init; }
    // public required ReadCartDto Cart { get; init; }
    // public required List<AddressDto> Addresses { get; init; }
    // public required List<ReadReviewDto> Reviews { get; init; }
    // public required List<ReadOrderDto> Orders { get; init; }
}  