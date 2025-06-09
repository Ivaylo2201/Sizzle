using Application.DTOs.Address;
using Core.Abstractions;
using MediatR;

namespace Application.CQRS.Addresses.Commands;

public record UpdateAddressCommand(UpdateAddressDto Dto) : 
    IRequest<Result>;