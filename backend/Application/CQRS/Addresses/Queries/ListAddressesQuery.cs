using Core.Abstractions;
using Core.Entities;
using MediatR;

namespace Application.CQRS.Addresses.Queries;

public record ListAddressesQuery(int UserId) : IRequest<Result<List<Address>>>;