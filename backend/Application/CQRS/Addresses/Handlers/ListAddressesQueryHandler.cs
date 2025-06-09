using Application.CQRS.Addresses.Queries;
using Application.DTOs.Address;
using Application.Extensions;
using Core.Abstractions;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Addresses.Handlers;

public class ListAddressesQueryHandler(IAddressRepository addressRepository) : 
    IRequestHandler<ListAddressesQuery, Result<List<ReadAddressDto>>>
{
    public async Task<Result<List<ReadAddressDto>>> Handle(ListAddressesQuery request, CancellationToken cancellationToken)
    {
        var result = await addressRepository.GetAllAddressesForUser(request.UserId);
        var addressDtos = result.Value.Select(a => a.ToDto()).ToList();
        return Result.Success(addressDtos);
    }
}