using Core.Abstractions;
using MediatR;
using Core.Entities;

namespace Application.CQRS.Items.Commands;

public record CreateItemCommand(Guid ProductId, int Quantity, int CartId) : IRequest<Result<Item>>;