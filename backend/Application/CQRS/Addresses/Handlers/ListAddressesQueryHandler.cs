using Application.CQRS.Addresses.Queries;
using Application.DTOs.Address;
using Application.Extensions;
using Core.Abstractions;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Addresses.Handlers;

public class ListAddressesQueryHandler(IAddressRepository addressRepository, IUserRepository userRepository) : 
    IRequestHandler<ListAddressesQuery, Result<List<GetAddressDto>?>>
{
    public async Task<Result<List<GetAddressDto>?>> Handle(ListAddressesQuery request, CancellationToken cancellationToken)
    {
        var userResult = await userRepository.GetOne(request.UserId);
        
        if (!userResult.IsSuccess || userResult.Value == null)
            return Result.Failure<List<GetAddressDto>?>(userResult.Error);

        var addressResult = await addressRepository.GetAllAddressesForUser(request.UserId);
        var addressDtos = addressResult.Value.Select(a => a.ToDto()).ToList();
        return Result.Success<List<GetAddressDto>?>(addressDtos);
    }
}