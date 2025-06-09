using Application.CQRS.Addresses.Commands;
using Core.Abstractions;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Addresses.Handlers;

public class UpdateAddressCommandHandler(IAddressRepository addressRepository) : 
    IRequestHandler<UpdateAddressCommand, Result>
{
    public async Task<Result> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        var result = await addressRepository.GetOne(request.Dto.Id);

        if (!result.IsSuccess || result.Value is null)
            return Result.Failure(result.Error);

        var address = result.Value;
        address.CityId = request.Dto.CityId;
        address.StreetName = request.Dto.StreetName;
        address.StreetNumber = request.Dto.StreetNumber;
        
        return await addressRepository.Update(address);
    }
}