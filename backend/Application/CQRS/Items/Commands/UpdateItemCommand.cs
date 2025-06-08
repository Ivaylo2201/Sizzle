using Core.Abstractions;
using MediatR;

namespace Application.CQRS.Items.Commands;

public record UpdateItemCommand(int ItemId, int Quantity) : IRequest<Result>;