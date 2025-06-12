using MediatR;

namespace Application.CQRS.Addresses.Commands;

public record DeleteAddressCommand(int Id) : IRequest<Unit>;