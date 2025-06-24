using Core.Abstractions;
using MediatR;

namespace Application.CQRS.Cities.Queries;

public record GetCityQuery(string CityName) : IRequest<Result<Core.Entities.City>>;