namespace WebAPI.Requests;

public record UpdateItemRequest
{
    public int Quantity { get; init; } = 1;
}