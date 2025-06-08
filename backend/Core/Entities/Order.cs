﻿namespace Core.Entities;

public class Order
{
    public int Id { get; init; }
    public int UserId { get; init; }
    public User User { get; init; } = null!;
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    public ICollection<Item> Items { get; init; } = new List<Item>();
}