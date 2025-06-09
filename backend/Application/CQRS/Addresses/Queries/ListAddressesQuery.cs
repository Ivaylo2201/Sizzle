using Application.DTOs.Address;
using Core.Abstractions;
using MediatR;

namespace Application.CQRS.Addresses.Queries;

public record ListAddressesQuery(int UserId) : IRequest<Result<List<GetAddressDto>?>>;