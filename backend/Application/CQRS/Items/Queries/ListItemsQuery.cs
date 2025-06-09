using Application.DTOs.Item;
using Core.Abstractions;
using MediatR;

namespace Application.CQRS.Items.Queries;

public record ListItemsQuery(int CartId) : IRequest<Result<List<ReadItemDto>?>>;