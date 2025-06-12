using Application.CQRS.Addresses.Commands;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Addresses.Handlers;

public class DeleteAddressCommandHandler(IAddressRepository addressRepository) : 
    IRequestHandler<DeleteAddressCommand, Unit>
{
    public async Task<Unit> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
    {
        await addressRepository.Delete(request.Id);
        return Unit.Value;
    }
}