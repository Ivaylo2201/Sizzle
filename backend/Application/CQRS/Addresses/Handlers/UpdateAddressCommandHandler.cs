using Application.CQRS.Addresses.Commands;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Addresses.Handlers;

public class UpdateAddressCommandHandler(IAddressRepository addressRepository) : 
    IRequestHandler<UpdateAddressCommand, Unit>
{
    public async Task<Unit> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        var address = request.Dto.Address;
        
        address.City = request.Dto.City;
        address.StreetName = request.Dto.StreetName;
        address.StreetNumber = request.Dto.StreetNumber;
        
        await addressRepository.Update(address);
        return Unit.Value;
    }
}