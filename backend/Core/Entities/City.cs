namespace Core.Entities;

public class City
{
    public int Id { get; set; }
    public required string CityName { get; set; }
    public ICollection<Address> Addresses { get; set; } = new List<Address>();
}