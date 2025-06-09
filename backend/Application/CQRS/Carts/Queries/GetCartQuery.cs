using Application.DTOs.Cart;
using Core.Abstractions;
using MediatR;

namespace Application.CQRS.Carts.Queries;

public record GetCartQuery(int UserId) : IRequest<Result<GetCartDto?>>;