using Application.DTOs.Address;
using Core.Abstractions;
using Core.Entities;
using MediatR;

namespace Application.CQRS.Addresses.Commands;

public record CreateAddressCommand(CreateAddressDto Dto) : 
    IRequest<Result<Address>>;