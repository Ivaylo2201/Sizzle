namespace Application.DTOs.Item;

public record CreateItemDto(Guid ProductId, int Quantity, int CartId);