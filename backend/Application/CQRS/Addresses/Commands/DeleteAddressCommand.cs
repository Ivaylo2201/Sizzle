using Application.DTOs.Address;
using Core.Abstractions;
using MediatR;

namespace Application.CQRS.Addresses.Commands;

public record DeleteAddressCommand(DeleteAddressDto Dto) : 
    IRequest<Result>;