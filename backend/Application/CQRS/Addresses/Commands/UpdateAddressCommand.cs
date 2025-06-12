using Application.DTOs.Address;
using MediatR;

namespace Application.CQRS.Addresses.Commands;

public record UpdateAddressCommand(UpdateAddressDto Dto) : IRequest<Unit>;