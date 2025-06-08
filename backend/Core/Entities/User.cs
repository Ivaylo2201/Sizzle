﻿namespace Core.Entities;

public class User
{
    public int Id { get; init; }
    public required string Username { get; init; }
    public required string PhoneNumber { get; set; }
    public required string Password { get; set; }
    public Cart Cart { get; init; } = null!;
    public ICollection<Address> Addresses { get; init; } = new List<Address>();
    public ICollection<Order> Orders { get; init; } = new List<Order>();
    public ICollection<Review> Reviews { get; init; } = new List<Review>();
}