using Application.CQRS.Addresses.Commands;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Addresses.Handlers;

public class CreateAddressCommandHandler(IAddressRepository addressRepository) 
    : IRequestHandler<CreateAddressCommand, Result<Address>>
{
    public async Task<Result<Address>> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        var address = new Address
        {
            CityId = request.Dto.CityId,
            StreetName = request.Dto.StreetName,
            StreetNumber = request.Dto.StreetNumber,
            UserId = request.Dto.UserId
        };
        
        return await addressRepository.Create(address); 
    }
}