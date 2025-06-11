using Application.DTOs.Item;
using Core.Abstractions;
using MediatR;

namespace Application.CQRS.Items.Queries;

public record GetItemQuery(int Id) : IRequest<Result<GetItemDto?>>;