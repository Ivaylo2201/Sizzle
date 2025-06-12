using Core.Abstractions;
using Core.Entities;
using MediatR;

namespace Application.CQRS.Addresses.Queries;

public record GetAddressQuery(int Id) : IRequest<Result<Address>>;