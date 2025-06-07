﻿namespace Core.Entities;

public class Review
{
    public int Id { get; set; }
    public required int Rating { get; set; }
    public string? Comment { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}