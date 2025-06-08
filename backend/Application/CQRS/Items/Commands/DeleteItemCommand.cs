using Application.DTOs.Item;
using Core.Abstractions;
using MediatR;

namespace Application.CQRS.Items.Commands;

public record DeleteItemCommand(DeleteItemDto Dto) : IRequest<Result>;