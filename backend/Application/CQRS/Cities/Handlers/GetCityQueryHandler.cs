using Application.CQRS.Cities.Queries;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Cities.Handlers;

public class GetCityQueryHandler(ICityRepository cityRepository) : IRequestHandler<GetCityQuery, Result<Core.Entities.City>>
{
    public async Task<Result<City>> Handle(GetCityQuery request, CancellationToken cancellationToken)
    {
        var cityResult = await cityRepository.GetOneByNameAsync(request.CityName);
        return Result.Success(cityResult.Value);
    }
}