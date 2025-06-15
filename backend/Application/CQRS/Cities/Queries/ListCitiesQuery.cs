using Core.Abstractions;
using MediatR;

namespace Application.CQRS.Cities.Queries;

public record ListCitiesQuery : IRequest<Result<List<Core.Entities.City>>>;