namespace Core.Entities;

public class Address
{
    public int Id { get; init; }
    public int CityId { get; set; }
    public City City { get; set; } = null!;
    public required string StreetName { get; set; }
    public required int StreetNumber { get; set; }
    public int UserId { get; init; }
    public User User { get; init; } = null!;
}