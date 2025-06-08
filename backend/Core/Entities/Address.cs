namespace Core.Entities;

public class Address
{
    public int Id { get; init; }
    public int CityId { get; init; }
    public City City { get; init; } = null!;
    public required string StreetName { get; init; }
    public required int StreetNumber { get; init; }
    public int UserId { get; init; }
    public User User { get; init; } = null!;
}