using Application.DTOs.Item;
using Core.Abstractions;
using MediatR;

namespace Application.CQRS.Items.Commands;

public record UpdateItemCommand(UpdateItemDto Dto) : IRequest<Result>;