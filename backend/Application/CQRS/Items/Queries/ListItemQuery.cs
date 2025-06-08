using Core.Abstractions;
using Core.Entities;
using MediatR;

namespace Application.CQRS.Items.Queries;

public record ListItemQuery(int CartId) : IRequest<Result<List<Item>>>;