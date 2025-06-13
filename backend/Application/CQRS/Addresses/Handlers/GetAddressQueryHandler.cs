using Application.CQRS.Addresses.Queries;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Addresses.Handlers;

public class GetAddressQueryHandler(IAddressRepository addressRepository) 
    : IRequestHandler<GetAddressQuery, Result<Address>>
{
    public async Task<Result<Address>> Handle(GetAddressQuery request, CancellationToken cancellationToken)
    {
        var result = await addressRepository.GetOneAsync(request.Id);
        
        return !result.IsSuccess
            ? Result.Failure<Address>(result.Error)
            : Result.Success(result.Value);
    }
}