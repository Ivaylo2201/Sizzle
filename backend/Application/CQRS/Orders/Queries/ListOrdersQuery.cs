using Application.DTOs.Order;
using Core.Abstractions;
using MediatR;

namespace Application.CQRS.Orders.Queries;

public record ListOrdersQuery(int UserId) : IRequest<Result<List<ReadOrderDto>>>;