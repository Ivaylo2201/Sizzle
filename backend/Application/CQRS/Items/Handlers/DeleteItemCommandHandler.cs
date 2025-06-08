using Application.CQRS.Items.Commands;
using Core.Abstractions;
using Core.Interfaces;
using MediatR;

namespace Application.CQRS.Items.Handlers;

public class DeleteItemCommandHandler(IItemRepository repository) : IRequestHandler<DeleteItemCommand, Result>
{
    public async Task<Result> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
    {
        return await repository.Delete(request.Id);
    }
}