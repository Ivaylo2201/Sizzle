using Application.CQRS.Addresses.Queries;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Addresses.Handlers;

public class ListAddressesQueryHandler(IAddressRepository addressRepository) : IRequestHandler<ListAddressesQuery, Result<List<Address>>>
{
    public async Task<Result<List<Address>>> Handle(ListAddressesQuery request, CancellationToken cancellationToken)
    {
        var addressResult = await addressRepository.GetAllAddressesForUserAsync(request.UserId);
        return Result.Success(addressResult.Value);
    }
}