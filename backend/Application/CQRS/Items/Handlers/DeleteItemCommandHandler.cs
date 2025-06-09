using Application.CQRS.Items.Commands;
using Core.Abstractions;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Items.Handlers;

public class DeleteItemCommandHandler(IItemRepository itemRepository) : 
    IRequestHandler<DeleteItemCommand, Result>
{
    public async Task<Result> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
    {
        return await itemRepository.Delete(request.Dto.Id);
    }
}