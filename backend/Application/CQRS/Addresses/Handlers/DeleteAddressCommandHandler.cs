using Application.CQRS.Addresses.Commands;
using Core.Abstractions;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Addresses.Handlers;

public class DeleteAddressCommandHandler(IAddressRepository addressRepository) : 
    IRequestHandler<DeleteAddressCommand, Result>
{
    public async Task<Result> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
    {
        return await addressRepository.Delete(request.Dto.Id);
    }
}